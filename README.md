# DeCodeHive

# Ecommerce Book Selling

Creating migrations
add-migration
update-database

## Initial Project Folders Explanation

When you run an empty project you will see RenderBody goes to MapControllerRoute. It calls controller of home page

### 1. Connected Services

### 2. Dependencies
This will tell the libraries on which our project is dependent. No dependency right now

### 3. Properties
Launchsettings.jason: It tells what settings must be used e.g url of the website against http profile(we are using http right now), port number

### 4. wwwroot
Host all of the static content(javascript css pdfs powerpoint without html)
Will add all static things we will put in this folder

### 5. Controllers
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
Inside controller there are action methods
Index() is called
IActionResult is class implemented in .net framework

### 6. Models
All the database attributes are defined here

### 7. Views
Static pages
Shared/ _Layout.cshtml is master page and we have specified this in _ViewStart.cshtml 
This master page has the navigation bar

### 8. appsettings.json
Host all of the connection strings or secret keys 

### 9. C# Program.cs
Configure middleware and adding services.
Configure something in pipeline


# Project Explanation
# Folders
## Models
### class Category
Who will tell Id is primary key? We will use data annotations for this
#### Data Annotation: 
Attributes that can be applied to classes or class members to specify the relationship between classes, describe how the data is to be displayed in the UI, and specify validation rules.<br>
[key] attribute will tell the IDE that this is a primary key<br>
[Required] attribute indicates that a property must have a value and cannot be null.<br>


# Procedure Followed

# CRUD OPERATIONS
## How To create a Table in Database
1. Inside Model folder create a model with some characteristics like we made Category Class<br>
2. Next in application DB context we have to create a DB set for that like as we did<br>
### public DbSet<Category>Categories{get; set; }<br>
3. Than in NuGet Package manager console, we have to add migration using<br>
### add-migration Migration name
4. Then run command update database and that will push migrations to the database. And with that we have created our categories table in our database.

## Now create a catgory Controller as we have Home controller
Always write Controller keyword at the end of Controller file so that it can be recognized<br>
A file will be created that will return view but if the view is not defind like it already created for home then exception will occur<br>
Create a new folder named Category inside view and inside category make a an empty razor file index.cshtml now all the html written here will be seen in website<br>

## Add Category Records to our Database
In file ApplicationDbContext: override method and add records of categories<br>
Then run migration<br>
Whenever anything has to be updated with database, we have to add a migration.<br>
To apply changes apply command: update-database<br>

## How to view those categories in our website
Get All categories

## How to pass list object to views
Views will have html,javascript, cs 

## For front end we will use a theme from website [https://bootswatch.com/]
1. Replace the min.css file with existing whose path is mentioned inside _Layout.cshtml<br>
 <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css" /><br>
2. We will copy the downloaded code to bootstrap.css and also change bootstrap.min.css to bootstrap.css in _Layout.cshtml<br>
3. For icons go for [https://icons.getbootstrap.com/] and copy CDN to your  _Layout.cshtml<br>

## Adding ADD CATEGORY BUTTON
Now we want to work on creating a new category. For that, it will be a new page.But when we work with creating a new page, we do not go by directly creating a view.We first have to create an action method that will be invoked and that will call the View.That action method, we will be adding inside the category controller.
We will make a view

## Create Category Form
Inside create category.We need a form where user can input name of the category and display order and we need a submit button.
Now create a function in controller against post

### Add Server side Validations
We are getting input name can not exceed length<br>
Order number can never be negative<br>
1. Use Helper tags in controller<br>
if you want to display error message then use tag helpers to do so<br>
asp-validation-summary="All"<br>
this will write the datamember name <br>

### Add client side validations using javascript
_validationScripts have all the validations and we will add its link to our category html file<br>
Client side validations doesnot go to server and continue to display without hitting create button<br>

## Adding Edit and delete buttons
1. Add buttons in index.html and define actions = Edit<br>
2. Then go to category controller define a function there that will receive id and will find it from database and edit it<br>
3. Then post will save it in database<br>

## Adding Notifications
1. Use partial Views for that<br>
2. Then go to toastr website for better view of Notifications<br>

### Toastr Notifications

1. Link to toastr.css <link href="toastr.css" rel="stylesheet"/><br>
2. Link to toastr.js <script src="toastr.js"></script><br>
3. use toastr to display a toast for info, success, warning or error<br>
toastr.info('Hey I am Notification')<br>

Now divide the whole code into multiple classe inside same solution<br>
I made the following Projects
1. Ecommerce.DataAccess<br>
2. Ecommerce.Models<br>
3. Ecommerce.Utility<br>

# CRUD Operations using our own Repository

## Steps

1. Inside Ecommerce.DataAccess make a folder named Repository<br>
2. Inside Repository make another Folder IRepository. It will contain interfaces<br>
3. First Create Interface IRepository. It will cotain basic operations that any class will have to implement<br>
4. Create another interface ICategoryRepository that will inherit IRepository and have 2 extra functions that we will use delete from database and commit changes to database i.e Update and SaveChanges<br>
4.1 Save method will be there in all the individual repositories. But the save functionality is not relevant to the repository or the model. So the correct way of doing things is to have this save in something called as unit of work.<br>
5. Then create a class Repository that will inherit IRepository<br>
6. Create class CategoryRepository that will inherit ICategoryRepository<br>

## IRepository Class

Understanding T Get(Expression<Func<T, bool>> filter);<br>

These expressions can be compiled and executed later, allowing you to delay the actual execution of code until you're ready. This is useful for scenarios where you want to build complex queries or dynamically generate code.<br>

Expression trees are often used in libraries like LINQ to build queries against databases or collections. Instead of executing a query immediately, you build an expression tree that represents the query, and then it's executed when needed<br>

# Dividing Project Into Areas
{area:exists} must be added to the pattern<br>
we will add default area as customer in program.cs<br>
_Viewimports and viewStart must be in Admin and Customer View<br>

## Admin Area
1. CategoryController and its view(managed by admin)<br>

## Customer Area
1. HomeController and its view(viewed by Customer)<br>

=> navlinks must know area<br>
If you do not write the area, it will look for that controller in the existing area where the page is already residing.<br>
And now when we are working with routing, we will define area first, then controller and then the action name<br>

# Adding Products to our Categories
Create Controllers and views by copying from Category Controllers<br>
Update the datamembers and rest is same<br>

## Relation Between Products and Categories
Any product that we have will belong to one of the category. So that will be a foreign key relation between product and category table.<br>
1. define foreign key and run migration<br>

## Drop Down of Categories in Product
Need List of Categories in controller to make drop down<br>

### View Bag
It is a dynamic property and transfers data from controller to view and not vice versa<br>
Any number of properties and values can be assigned to a it and their life only exist during the current HTTP request<br>
Its values will be null if there is any redirection<br>
It is actually a wrapper around view data<br>

## Adding images to form
Product Controller upsert contains the whole detail about that<br>

# Creation of Home page
Just Html and bootsrap make views as we made previous<br>
