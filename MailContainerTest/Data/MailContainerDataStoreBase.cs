using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailContainerTest.Types;

namespace MailContainerTest.Data
{
    public abstract class MailContainerDataStoreBase : IMailContainerDataStore
    {
        // User can inherit and provide implementation of below methods. WE can also use Liskov Substitution method that will by default introduce open/close
        public virtual MailContainer GetMailContainer(string mailContainerNumber)
        {
            // Access the database and return the retrieved mail container. Implementation not required for this exercise.
            return new MailContainer();
        }
        public virtual void UpdateMailContainer(MailContainer mailContainer)
        {
            // Update mail container in the database. Implementation not required for this exercise.
        }
    }
}
