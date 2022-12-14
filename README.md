### Mail Container Test 

The code for this exercise has been developed to manage the transfer of mail items from one container to another for processing.

#### Process for transferring mail

- Lookup the container the mail is being transferred from.
- Check the containers are in a valid state for the transfer to take place.
- Reduce the container capacity on the source container and increase the destination container capacity by the same amount.

#### Restrictions

- A container can only hold one type of mail.


#### Assumptions

- For the sake of simplicity, we can assume the containers have an unlimited capacity.
 

### The exercise brief

The exercise is to take the code in the solution and refactor it into a more suitable approach with the following things in mind:

- Testability
- Readability
- SOLID principles
- Architectural design of the code

You should not change the method signature of the MakeMailTransfer method.

You should add suitable tests into the MailContainerTest.Test project.

There are no additional constraints, use the packages and approach you feel appropriate, aim to spend no more than 2 hours. Please update the readme with specific comments on any areas that are unfinished and what you would cover given more time.

### Dev Work done by Ashish

-To Access Data, I have used dependency injection in Service class.

-Using abstract class In Data to avoid duplicate code, GetContainer and Update Container methods are used in BackupMailContainerDataStore
and in MailContainerDataStore, Having same code. This also implements open/close Solid principle

- We could also have Liskov instead abstract class that too implement open/Close.

- For testcase, I have used Xunit.
- In data Folder we are also using Repository Design pattern and intorduced new Interface.
