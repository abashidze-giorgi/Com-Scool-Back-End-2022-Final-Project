# Final-Project-December-2022

 ## Technologies
 

 - **.net 5.0**
 - **MicrosoftFrameWorkCore**
 - **MicrosoftFrameWorkCore.SqlServer**
 - **MicrosoftFrameWorkCore.Tools**
 - **Swagger**
 - **FluentValidation**.

 
## Getting Started

1.  Install the latest  [.NET 5 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/5.0)
2.  Install the latest  [# SQL Server Management Studio (SSMS) 19 (Preview)](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms-19?view=sql-server-ver16)
3.  You must have the 2022 version of [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads?rtc=1) installed.
4. Install with [NutGet](https://www.nuget.org/) the packages mentioned above in technologies.


### [](https://github.com/jasontaylordev/CleanArchitecture#database-configuration)Database Configuration

#### You can create a database directly from the program. 
#### Completion of the operation, enter Update-Database

Verify that the  **DefaultConnection**  connection string within  **appsettings.json**  points to a valid SQL Server instance.



### [](https://github.com/jasontaylordev/CleanArchitecture#database-migrations)Database Migrations
in the **Package manager Console**, type **Add-Migration newMigration** and after process is done, enter **Update-Database**.

When you run all commands, the database will be automatically created (if necessary) and the latest migrations will be applied.
commands:


## [](https://github.com/jasontaylordev/CleanArchitecture#overview)Overview
The program can create, edit and delete Users and create, edit, cover, and delete loans.
one user can have several loans. the program can change the status and type of loan.

 - **user registration**
 - **Return information about the user by ID**
 - **The user can add a loan (save in the database)**
 - **When creating a new loan, the status is "processing"**
 - **You can change the status of the loan**
 - **Users can view, update,  delete their own loans**
 - **Loan renewal and deletion is possible  only if the status is "processing"**
 - **In case of an error, a log  entry is created about the error**
 - **The program validates requests. All input data is verified** 
   
### [](https://github.com/jasontaylordev/CleanArchitecture#domain)Domain

This will contain all  object classes, these are **USER** and **LOAN**.

All relations for the database are registered in **Data**.

In the **Controllers** folder there are **LoanController** and **UserController**, they  are responsible for operations on their classes.

###  Classes
## The **User** class has the following options and looks like this:
		int Id, 
		string FirstName,
		string LastName, 
		string UserName, 
		int Age, 
		string Email, 
		double Salary, 
		List<LOAN> Loans.

	public class User : IUserInterface
	{
		private int _id;
		private string _firstName;
		private string _lastName;
		private string _userName;
		private int _age;
		private string _email;
		private int _salary;
		private List<Loan> _loans = new List<Loan>();
		
		public int Id { get => _id; set => _id = value; }
		public string FirstName { get => _firstName; set => _firstName = value; }
		public string LastName { get => _lastName; set => _lastName = value; }
		public string UserName { get => _userName; set => _userName = value; }
		public int Age { get => _age; set => _age = value; }
		public string Email { get => _email; set => _email = value; }
		public int Salary { get => _salary; set => _salary = value; }
		public List<Loan> Loans { get => _loans; set => _loans = value; }
	}

---------------------------------------------------------------

## The **Loan**class has the following options and looks like this:
		int Id
        USER User
        int UserId
        Type Type
        double Amount
        string Valute
        int Period
        Status Status

	    public class LOAN
	    {
	        public int Id { get; set; }
	        public USER User { get; set; }
	        public int UserId { get; set; }
	        public Type Type { get; set; }
	        public double Amount { get; set; }
	        public string Valute { get; set; }
	        public int Period { get; set; }
	        public Status Status { get; set; }
	    }
	   public enum Status
	    {
	        Processing,
	        Approved,
	        Rejected
	    };
	    public enum Type
	    {
	        auto_loan,
	        fast_loan,
	        Installment
	    }
	}

## The **Log**class has the following options and looks like this:
		
		int _id;
		DateTime _createdDate;
		string _name;
		string _message;
		string _helpLink;
		string _stackTrace;
		string _source;


	public class Log : ILogInterface
	{
		private int _id;
		private DateTime _createdDate = new DateTime();
		private string _name;
		private string _message;
		private string _helpLink;
		private string _stackTrace;
		private string _source;
		
		public int Id { get => _id; set => _id = value; }
		public DateTime CreatedDate { get => _createdDate; set => _createdDate = value; }
		public string MethodName { get => _name; set => _name = value; }
		public string Message { get => _message; set => _message = value; }
		public string HelpLink { get => _helpLink; set => _helpLink = value; }
		public string StackTrace { get => _stackTrace; set => _stackTrace = value; }
		public string Source { get => _source; set => _source = value; }
	}
