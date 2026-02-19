A Windows App made with Winforms and C# that mainly uses a MSSQL connection to save data. The program is a pretend like banking program, that let's you create customers, addresses that multiple customers can reside in, bank accounts for a specific customer and transactions that include one or two accounts. 

---
## Images
![Startscreen](images/DBConnection.png)
The startscreen, where the connection will be established, default data can be inserted and all data deleted.
\
\
\
![CustomerAddressTab](images/CustomerAddressTab.png)
Overview of all customers and addresses along with the ability to add, change and delete selected data.

---

## Functions

- Connection to MSSQL DB though LogIn
- Creation of addresses, customers, bank accounts and transactions
- Insertion of default data
- Deletion of all data
- Overview of all data
- Overview of all accounts tied to a specific customer
- Overview of all transactions associated to a specific account
- Deletion of selected data
- Saving of data to DB after any change

---

## Installing

1. Clone repo:
   ```bash
   git clone https://github.com/Pancham674/BankingSiteProject.git
   cd BankingSiteProject
   
2. Run program
   ````bash
   dotnet build
   bin\Debug\BankingSite.exe
