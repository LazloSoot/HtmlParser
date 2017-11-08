using System.Windows.Forms;

namespace HtmlParser
{
    interface IMessageService
    {
        void ShowError(string message);
        void ShowError(string message, IWin32Window owner);
        void ShowMessage(string message);
    }
    class MessageService : IMessageService
    {
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void ShowError(string message, IWin32Window owner)
        {
            MessageBox.Show(owner, message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
