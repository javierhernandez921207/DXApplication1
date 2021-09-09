using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace DXApplication1.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ModelDefault("Caption", "Task")]
    public class DemoTask : Task
    {
        public DemoTask(Session session) : base(session) { }
        [Association("Contact-DemoTask")]
        public XPCollection<Contact> Contacts
        {
            get
            {
                return GetCollection<Contact>(nameof(Contacts));
            }
        }
        private Priority priority;
        public Priority Priority
        {
            get { return priority; }
            set
            {
                SetPropertyValue(nameof(Priority), ref priority, value);
            }
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Priority = Priority.Normal;
        }

    }
    public enum Priority
    {
        Low,
        Normal,
        High
    }
}
