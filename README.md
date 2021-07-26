# dotNetGroupProject
Repo for a group project for WSU's  CS3280
Group Assignment (May not be turned in late)

Create a Windows WPF program that can be used as in invoice system for a small business.  The type of business is up to you.  Examples of a business would be a Supplement Store, Jewelry Store, Shoe Store, Equipment Rental Store, etc.  A Microsoft Access database should be used as the backend database to store the invoice data.  The group assignment will be turned in by one member of the group.

The group project will be broken up so that each member is responsible for everything for a single Window.  So, for a 3-person team, one person will do everything for the Main Window, another person does the Search Window, and the last does the Edit Items Window.

The Visual Studio project will be created and 3 folders will be added to the project.  The folders will be called “Search”, “Main”, and “Items”.  Inside these folders, each member will put their respective code files. 

For the “Search” folder, there should be a XAML file for the UI called “wndSearch.xaml”, another file named “clsSearchSQL” which contains all SQL statements for the Search Window, and the last file should be “clsSearchLogic” which will contain all business logic for the Search Window.

For the “Main” folder, there should be a XAML file for the UI called “wndMain.xaml”, another file named “clsMainSQL” which contains all SQL statements for the Main Window, and the last file should be “clsMainLogic” which will contain all business logic for the Main Window.

For the “Items” folder, there should be a XAML file for the UI called “wndItems.xaml”, another file named “clsItemsSQL” which contains all SQL statements for the Items Window, and the last file should be “clsItemsLogic” which will contain all business logic for the Items Window.

The main window should allow the user to create new invoices, edit existing invoices, or delete existing invoices.  There should be just one window for all functionality of the main window.  So, the main window will NOT open other windows to add/edit/delete invoices.  It will also have a menu (at the top, use a menu control) that will have two functionalities.  The first will allow the user to update a def table that contains the items.  The next will be to open a search screen used to search for invoices.

If a new invoice is created the user may enter data pertaining to that invoice.  Since an auto-generated number is used in the database for the invoice number, when a user creates a new invoice, just display “TBD” for the Invoice Number.  An invoice date will also be assigned by the user.  Next different items will be entered by the user.  The items will be selected from a drop-down box and the cost for that item will be put into a read only textbox.  This will be the default cost of an item. Once the item is selected, the user can add the item.  As many items as needed should be able to be added.  All items entered should be displayed for viewing in a list (something like a DataGrid).  Items may be deleted from the list.  A running total of the cost of all items should be displayed as items are entered or deleted.

Once all the items are entered the user can save the invoice.  Once the Invoice is saved, query the max invoice number from the database, to display for the invoice number (for our project, this will work, since the last inserted invoice, will be the max).  This will lock the data in the invoice for viewing only.  From here the user may choose to Edit the Invoice or Delete the Invoice. 

The user also needs to be able to search for invoices, which will be a choice from the menu.  On the search screen, all invoices should be displayed in a list (like a DataGrid) for the user to select.  The user may limit the invoices displayed by choosing an Invoice Number from a drop down, selecting an invoice date, or selecting the total charge from a drop-down box.  The total charges in the drop-down box should be the unique set of total charges sorted from smallest to largest.  When a limiting item is selected, the list should only reflect those invoices that match the criteria.  So, the user should be able to select a date and a total charge, and only invoices that match both will be displayed.  A clear selection button should reset the form to its initial state.  Once an invoice is selected the user will click a “Select Invoice” button, which will close the search form and open the selected invoice up for viewing on the main screen.  From there the user may choose to Edit or Delete the invoice.

The last form needed is a form to update the def table which contains all the items for the business.  This form can be accessed through the menu and only when an invoice is not being edited or a new invoice is being entered.  This form will list all the items in a list (like a DataGrid).  The items will consist of a code, cost, and description.  From here the user can add new items, edit existing items, or delete existing items.  If the user tries to delete an item that is on an invoice, don’t allow the user to do so.  Instead warn them with a message that tells the user which invoices that item is used on.  When an item is updated, the code must not be allowed to be updated because it is the primary key, only the description and cost may be updated.  When the user closes the update def table form, make sure to update the drop-down box as to reflect any changes made by the user.  Also update the current invoice because its item name might have been updated.

Since this is the final project all lessons learned throughout the course should be used and implemented.  Don’t forget to abstract your business logic into classes and keep you UI code clean.  Make sure to test all user inputs so your program doesn’t crash, have another group member test your code thoroughly.  All methods should handle exceptions.  Since this a WPF application you should use styles for your applications.  At a minimum, a theme should be applied to the application, such as one talked about in the Microsoft Blend lecture.  Visual properties shouldn’t be hard coded into controls, they should be put into styles and applied to controls.

 

 

Guidelines

- Project Submission: you must turn it in by midnight on the due date.

- Only one person should submit the assignment with all members’ name in the email.

 

Common Mistakes

- Student's didn't unit test each other’s code

- Forgot to use styles

- Business logic behind the UI

- Validate all user input

 

Tips

- Run each other’s code to test for bugs

- Look at each other’s code

- Verify all requirements

- Run through the presentation together

- Break up the project so that each member is responsible for everything for a single Window.

 

DataGrid Help

Keeps thing simple.
On the edit item screen, instead of using the DataGrid like an excel spreadsheet, just show each selected item in textboxes next to the DataGrid
To get rid of the extra row on the bottom of the DataGrid set the following property:
CanUserAddRows="False"
 

Microsoft Access Help

To view data in a table: In the “Tables” menu on the left-hand side of the screen, double click the data you wish to the view the data for.

 

To create and test queries: Click the “Create” ribbon item, click the “Query Design” button.  This brings up the ability to create queries in a designer, if you know how to work this go ahead, if you want to write queries manually and test them, then close the “Show Table” window, then click the “SQL View” button at the top left corner, select “SQL View”.  Now create your SQL statements, then click the “Run” button on the ribbon.

 

Commonly Missed Items

Search

- Requirement to “On the search screen all invoices should be displayed in a list”.

- On the search screen the combo boxes should only have distinct values, not duplicates, and should be ordered so users can find the values they need.

- Search window has business logic behind the UI.

- Search window, the date and total charge should be combined as a filter if both are selected.

- Requirement to have a clear selection button.

- Each time the search window is opened it should refresh invoices and combo boxes because an invoice could have been updated or deleted.

- Requirement to theme the application.

- All Classes, Attributes, and Methods need XML comments.

- Try catch blocks not implemented correctly.

- All methods need a try catch block

- All business logic has been put into the classes that are just supposed to be SQL statements.
