A Windows App made with Winforms  and C# that mainly uses a MSSQL connection to save data. The program is a pretend like banking program, that let's you create customers, addresses multiple customers reside in, bank accounts for specific customer and transactions of or between two accounts. 

---
## Images
![Startscreen](images/DBConnection.png)
The startscreen, where the connection will be established and default data can be inserted.
\
\
\
![CustomerAddressTab](images/CustomerAddressTab.png)
Overview of all customers and addresses along with the ability to add, change and delete selected data.

---

## Functions

- Connection to MSSQL DB though LogIn
- Creation of addresses, customers, bank accounts and transactions
- Isertion of default data
- Overview of all data
- Overview of all accounts of specific customer
- Overview of all transactions of specific account
- Deletion of selected data
- Saving of data to DB after any change

---

## Installing

1. Clone repo:
   ```bash
   git clone https://github.com/Pancham674/BankingSite.git
   cd BankingSite
   
2. Run program
   ````bash
   dotnet build
   BankingSite\bin\Debug\net8.0-windows\BankingSite.exe
