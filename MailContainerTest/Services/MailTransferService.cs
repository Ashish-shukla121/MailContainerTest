using MailContainerTest.Data;
using MailContainerTest.Types;
using System.Configuration;

namespace MailContainerTest.Services
{
    public class MailTransferService : IMailTransferService
    {
        private readonly IMailContainerDataStore _mailContainerDataStore;
        // injecting dependency to access Data Layer
        public MailTransferService( IMailContainerDataStore mailContainerDataStore)
        {
           this._mailContainerDataStore = mailContainerDataStore;
        }
        public MakeMailTransferResult MakeMailTransfer(MakeMailTransferRequest makeMailTransferRequest)
        {
            if (makeMailTransferRequest is null)
            {
                throw new ArgumentNullException(nameof(makeMailTransferRequest));
            }

            var mailContainer = _mailContainerDataStore.GetMailContainer(makeMailTransferRequest.SourceMailContainerNumber);
            var makeMailTransferResult = new MakeMailTransferResult();
            var dataStoreType = ConfigurationManager.AppSettings["DataStoreType"];
            
            try
            {
                // Checking here whether Mail container is in operation state or not
                // Fail Fast Approach. Checking here mail container status. If it is not in operation state than throwing exception.
                if (mailContainer.Status != 0)
                {
                    throw new Exception("Mail container is not in operational state!");
                }
                else
                {
                    var checkMailTypeResult = CheckMailType(makeMailTransferRequest, mailContainer, makeMailTransferResult);
                    if (!checkMailTypeResult.Equals(true))
                    {
                       return makeMailTransferResult;
                    }
                    else
                    {
                         mailContainer.Capacity -= makeMailTransferRequest.NumberOfMailItems;
                        _mailContainerDataStore.UpdateMailContainer(mailContainer);
                        return makeMailTransferResult;
                    }
                   
                }
               
            }
            // Try catch block to handle exceptions 
            catch (Exception ex)
            {
                // Message and stack trace will help developer finding details cause of exception.
                throw new Exception($"Getting error in Mail Transfer. Message: {ex.Message}, Error: {ex.StackTrace}");
            }
            return makeMailTransferResult;
        }

        private static bool CheckMailType(MakeMailTransferRequest makeMailTransferRequest, MailContainer mailContainer,
            MakeMailTransferResult makeMailTransferResult)
        {
            switch (makeMailTransferRequest.MailType)
            {
                case MailType.StandardLetter:
                    if (mailContainer == null)
                    {
                        makeMailTransferResult.Success = false;
                    }
                    else if (!mailContainer.AllowedMailType.HasFlag(AllowedMailType.StandardLetter))
                    {
                        makeMailTransferResult.Success = false;
                    }

                    break;

                case MailType.LargeLetter:
                    if (mailContainer == null)
                    {
                        makeMailTransferResult.Success = false;
                    }
                    else if (!mailContainer.AllowedMailType.HasFlag(AllowedMailType.LargeLetter))
                    {
                        makeMailTransferResult.Success = false;
                    }
                    else if (mailContainer.Capacity < makeMailTransferRequest.NumberOfMailItems)
                    {
                        makeMailTransferResult.Success = false;
                    }

                    break;

                case MailType.SmallParcel:
                    if (mailContainer == null)
                    {
                        makeMailTransferResult.Success = false;
                    }
                    else if (!mailContainer.AllowedMailType.HasFlag(AllowedMailType.SmallParcel))
                    {
                        makeMailTransferResult.Success = false;
                    }
                    else if (mailContainer.Status != MailContainerStatus.Operational)
                    {
                        makeMailTransferResult.Success = false;
                    }

                    break;
               
            }
            return makeMailTransferResult.Success;
        }
    }
}

