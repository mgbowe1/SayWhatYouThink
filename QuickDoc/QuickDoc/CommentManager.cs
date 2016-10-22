using System.Windows.Forms;

namespace QuickDoc
{
    public class CommentManager
    {
        private static CommentManager _instance = null;

        private CommentManager() { }

        public static CommentManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CommentManager();
                return _instance;
            }
        }

        public void WriteComment(string comment)
        {
            SendKeys.Send(comment);
        }
    }
}
