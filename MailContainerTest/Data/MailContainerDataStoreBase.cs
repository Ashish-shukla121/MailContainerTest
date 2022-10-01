using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailContainerTest.Types;

namespace MailContainerTest.Data
{
    public class MailContainerDataStoreBase : IMailContainerDataStore
    {
        public MailContainer GetMailContainer(string mailContainerNumber)
        {
            // Access the database and return the retrieved mail container. Implementation not required for this exercise.
            return new MailContainer();
        }

        public void UpdateMailContainer(MailContainer mailContainer)
        {
            // Update mail container in the database. Implementation not required for this exercise.
        }
    }
}
