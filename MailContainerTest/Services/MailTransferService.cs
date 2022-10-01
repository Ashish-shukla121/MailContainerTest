using MailContainerTest.Data;
using MailContainerTest.Types;
using System.Configuration;

namespace MailContainerTest.Services
{
    public class MailTransferService : IMailTransferService
    {
        private readonly IMailContainer _mailContainerStatus;
        // Assuming there is a mail container service that is checking the status of Mail Container.
        public MailTransferService(IMailContainer mailContainer)
        {
            _mailContainerStatus = mailContainer;
        }
        public MakeMailTransferResult MakeMailTransfer(MakeMailTransferRequest request)
        {
            var result = new MakeMailTransferResult();
            var dataStoreType = ConfigurationManager.AppSettings["DataStoreType"];
            MailContainer mailContainer = _mailContainerStatus;
            try
            {
                // Fail Fast Approach. Checking here mail container status. If it is not in operation state than throwing exception.
                if (mailContainer.Status != "Operational")
                {
                    throw new Exception("Mail container is not in opretational state!");
                }
                else
                {
                    if (dataStoreType == "Backup")
                    {
                        var mailContainerDataStore = new BackupMailContainerDataStore();
                        mailContainer = mailContainerDataStore.GetMailContainer(request.SourceMailContainerNumber);

                    }
                    else
                    {
                        var mailContainerDataStore = new MailContainerDataStore();
                        mailContainer = mailContainerDataStore.GetMailContainer(request.SourceMailContainerNumber);
                    }

                    switch (request.MailType)
                    {
                        case MailType.StandardLetter:
                            if (mailContainer == null)
                            {
                                result.Success = false;
                            }
                            else if (!mailContainer.AllowedMailType.HasFlag(AllowedMailType.StandardLetter))
                            {
                                result.Success = false;
                            }
                            break;

                        case MailType.LargeLetter:
                            if (mailContainer == null)
                            {
                                result.Success = false;
                            }
                            else if (!mailContainer.AllowedMailType.HasFlag(AllowedMailType.LargeLetter))
                            {
                                result.Success = false;
                            }
                            else if (mailContainer.Capacity < request.NumberOfMailItems)
                            {
                                result.Success = false;
                            }
                            break;

                        case MailType.SmallParcel:
                            if (mailContainer == null)
                            {
                                result.Success = false;
                            }
                            else if (!mailContainer.AllowedMailType.HasFlag(AllowedMailType.SmallParcel))
                            {
                                result.Success = false;

                            }
                            else if (mailContainer.Status != MailContainerStatus.Operational)
                            {
                                result.Success = false;
                            }
                            break;
                    }
                    // Checking the result, if it is not success senario than we are  throwing the exception.
                    if (!result.Success)
                    {
                        throw new Exception($"There were some error in fetching the result");
                    }
                    else
                    {
                        mailContainer.Capacity -= request.NumberOfMailItems;

                        if (dataStoreType == "Backup")
                        {
                            var mailContainerDataStore = new BackupMailContainerDataStore();
                            mailContainerDataStore.UpdateMailContainer(mailContainer);

                        }
                        else
                        {
                            var mailContainerDataStore = new MailContainerDataStore();
                            mailContainerDataStore.UpdateMailContainer(mailContainer);
                        }
                    }
                }
               
            }
            // Try catch block to handle exceptions 
            catch (Exception ex)
            {
                // Message and stack trace will help developer finding details cause of exception.
                throw new Exception($"Getting error in Mail Transfer. Message: {ex.Message}, Error: {ex.StackTrace}");
            }
            return result;
        }
        
    }
}

