using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Mtf.Core
{
    public class ExceptionCatcher
    {
        private readonly bool showUnhandledMessages;
        private readonly FileLogger fileLogger;
        private bool exitOnUnhandledException;
        private readonly string unhandledExceptionsFolder;

        public ExceptionCatcher() : this($"{Application.ProductName} - {Application.ProductVersion}")
        { }

        public ExceptionCatcher(string folder, bool showUnhandledMessages = true, bool exitOnUnhandledException = true, bool threadExceptionHandlerActivated = false)
        {
            Initialize(exitOnUnhandledException, threadExceptionHandlerActivated, UnhandledExceptionHandler);

            this.showUnhandledMessages = showUnhandledMessages;

            unhandledExceptionsFolder = $"{Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)}\\{folder}\\";
            fileLogger = new FileLogger(unhandledExceptionsFolder, "unhandled_exceptions.log");
        }

        public ExceptionCatcher(bool exitOnUnhandledException = true, bool threadExceptionHandlerActivated = false)
        {
            Initialize(exitOnUnhandledException, threadExceptionHandlerActivated, UnhandledExceptionHandler_2);
        }

        private void Initialize(bool exitOnUnhandledException, bool threadExceptionHandlerActivated, UnhandledExceptionEventHandler handlerFunction)
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            if (threadExceptionHandlerActivated)
            {
                Application.ThreadException += ThreadExceptionHandler;
            }

            this.exitOnUnhandledException = exitOnUnhandledException;

            var currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += handlerFunction;
        }

        private void ThreadExceptionHandler(object sender, ThreadExceptionEventArgs e)
        {
			var exception = !(sender is Thread thread) || String.IsNullOrEmpty(thread.Name) ? e.Exception : new Exception($"Exception occurred on the following thread: {thread.Name}", e.Exception);
			HandleException(exception);
        }

        private void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException(e.ExceptionObject as Exception);
        }

        private void UnhandledExceptionHandler_2(object sender, UnhandledExceptionEventArgs e)
        {
            ShowMessageBox(e.ExceptionObject as Exception);
        }

        private void HandleException(Exception ex)
        {
            var now = DateTime.UtcNow;

            var errorDetails = new StringBuilder();
            errorDetails.AppendLine($"{now.ToShortDateString()} {now.ToLongTimeString()}");
            errorDetails.Append(new ExceptionDetails(ex).Details);

            fileLogger.Log(errorDetails.ToString());
            if (showUnhandledMessages)
            {
                try
                {
                    ErrorBox.Show(ex, Timeout.Infinite);
                }
                catch
                {
                    ShowException(ex);
                }
            }

            if (exitOnUnhandledException)
            {
                Environment.Exit(-1);
            }
        }

        private void ShowMessageBox(Exception ex)
        {
            ShowException(ex);
            if (exitOnUnhandledException)
            {
                Environment.Exit(-1);
            }
        }

        private static void ShowException(Exception ex)
        {
            try
            {
                ErrorBox.Show(ex, Timeout.Infinite);
            }
            catch
            {
                MessageBox.Show($"{ex.Message}{Environment.NewLine}{ex.StackTrace}", ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}