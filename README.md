# EmployeeM

**EmployeeM** is a web-based system developed with ASP.NET MVC and ADO.NET for efficient employee management. The application includes role-based access control, department-specific theme customization, and secure authentication to streamline administrative tasks while ensuring data integrity and usability.  


![Alt text](https://github.com/Thaistg11/EmployeeM/blob/d2b3b9da77bea692704c2079d670c8b9f9485911/HomePageScreenshot.png?raw=true)


[Click here](https://employeem-webapp-avbebrcqfxd8dbhc.uksouth-01.azurewebsites.net/) to visit the deployed site.

To access admin, [click here](https://employeem-webapp-avbebrcqfxd8dbhc.uksouth-01.azurewebsites.net/)  

**User:** admin@gmail.com  
**Password:** Teste123*  

---

## Table of Contents

1. [Owner/Admin Stories](#owneradmin-stories)  
2. [User Stories](#user-stories)  
3. [Structure](#structure)  
4. [Features](#features)  
   - [User Features](#user-features)  
   - [Owner/Admin Features](#owneradmin-features)  
5. [Technologies Used](#technologies-used)  
6. [Applications, Libraries, and Platforms](#applications-libraries-and-platforms)  
7. [Validation](#validation)  
8. [Testing](#testing)  
9. [Future Improvements](#future-improvements)  
10. [Deployment / Live Demo](#deployment--live-demo)  
11. [Screenshots](#screenshots)
12.  [Author](#author)  
  

---

## Owner/Admin Stories

- As an **Admin**, I want full access to the system so I can manage employees, departments, and roles securely.  
- As an **Admin**, I want to assign roles and create new users to control access levels.  
- As a **Department Manager**, I want to manage employees only within my department to ensure data security and accuracy.  

---

## User Stories

- As an **Employee**, I want to view my details so I can confirm my information is correct.  
- As a **User**, I want to select a personalized theme so my department’s interface reflects our preferences.  
- As a **User**, I want to search and filter employees easily to find information quickly.  

---

## Structure

The project follows the **MVC architecture**:

- **Models**: Represent entities such as Employee, Department, Theme, and Roles.  
- **Views**: Razor pages that dynamically render content with responsive layouts.  
- **Controllers**: Handle user requests, interact with repositories, and return views.  
- **Repositories**: Handle ADO.NET database operations and stored procedures.  

---

## Features

### User Features

- View employee details dynamically.  
- Edit employee information inline and save changes.  
- Search and filter employee records by Name or ID.  
- Personalize department themes with custom colours and fonts.  

### Owner/Admin Features

- Manage all employees across departments.  
- Assign roles and create new users.  
- Configure department themes globally.  
- Access audit logs and ensure secure data handling.  

---

## Technologies Used

- **ASP.NET MVC** – Web application framework  
- **ADO.NET** – Database interaction  
- **ASP.NET Identity** – Authentication and role management  
- **C#** – Backend programming  
- **SQL Server** – Database  
- **Bootstrap** – Responsive UI  
- **Razor Views** – Dynamic frontend rendering  
- **Visual Studio** – IDE  
- **JavaScript** – Client-side interactions  

---

## Applications, Libraries, and Platforms

- **Font Awesome** – Fonts and icons used throughout the project  
- **Google Fonts** – Fonts used in the application design  
- **Git** – Version control system for committing and pushing code  
- **GitHub** – Repository hosting for the project and branches  
- **Gitpod** – Web-based IDE used for coding and testing  

---

## Validation

- Inline data validation before saving employee records.  
- Stored procedures ensure database integrity.  
- Role-based checks for restricted actions.  

---

## Testing

The following tests were conducted to verify EmployeeM’s functionalities:

### Test 1: View Employee Details
*"I would like to view employee details"*

**Actions:**  
- User enters Employee ID  
- Clicks “Search”  
- Employee details are displayed dynamically on the page  

**View image of the steps:**  
![Employee List]( https://raw.githubusercontent.com/Thaistg11/EmployeeM/d2b3b9da77bea692704c2079d670c8b9f9485911/EmployeeListScreenshot.png)

**Expected result:** Employee details are displayed correctly.  
**Actual result:** Works as intended.  

---

### Test 2: Edit Employee Information
*"I would like to edit employee information"*

**Actions:**  
- User selects an employee from the list  
- Edits fields such as Name, Department, or Role  
- Clicks “Save”  
- Validation checks ensure data is correct  

**View image of the steps:**  
![Description of image](https://raw.githubusercontent.com/Thaistg11/EmployeeM/d2b3b9da77bea692704c2079d670c8b9f9485911/Screenshot%202025-09-21%20002434.png)

**Expected result:** Employee information is updated in the database.  
**Actual result:** Works as intended.  

---

### Test 3: Role-Based Access Verification
*"I would like to ensure department managers cannot access other departments"*

**Actions:**  
- Log in as a Department Manager  
- Try accessing employees from other departments  

**View image of the steps:**  


 
![Employee List](https://raw.githubusercontent.com/Thaistg11/EmployeeM/d2b3b9da77bea692704c2079d670c8b9f9485911/EmployeeListItScreenshot.png)
 

**Expected result:** Access denied to other department’s data.  
**Actual result:** Works as intended.  

---

### Test 4: Department Theme Selection
*"I would like to select a theme for my department"*

**Actions:**  
- User opens Theme Settings  
- Chooses custom colours and fonts  
- Saves changes  

**View image of the steps:**  
![Different Theme Screenshot](https://raw.githubusercontent.com/Thaistg11/EmployeeM/d2b3b9da77bea692704c2079d670c8b9f9485911/DifferentThemeScreenshot.png)

  

**Expected result:** Theme is applied dynamically across all pages.  
**Actual result:** Works as intended.  

---

### Test 5: Search & Filter Employees
*"I would like to search for employees by name or ID"*

**Actions:**  
- User types Name or Employee ID into search field  
- Clicks “Search” or filters results  

**View image of the steps:**  
![Search Step](https://raw.githubusercontent.com/Thaistg11/EmployeeM/d2b3b9da77bea692704c2079d670c8b9f9485911/SearchBarScreenshot.png) 

**Expected result:** Only relevant employees are displayed.  
**Actual result:** Works as intended.  

---

### Test 6: Authentication
*"I would like to log in to access employee management features"*

**Actions:**  
- User enters credentials on the login page  
- Clicks “Login”  

**View image of the steps:**  
![Login Screenshot](https://raw.githubusercontent.com/Thaistg11/EmployeeM/d2b3b9da77bea692704c2079d670c8b9f9485911/LoginScreenshot.png)
  

**Expected result:** User is redirected to the homepage with proper role-based access.  
**Actual result:** Works as intended.  

---

## Future Improvements

While **EmployeeM** provides full functionality for employee management, role-based access, and department theme customization, it’s important to note that the **main focus of this project has been the backend and database layer**.  

The application prioritizes:  
- Secure authentication and authorization  
- Role-based data access  
- Efficient database operations with ADO.NET  
- Scalable and maintainable backend architecture  

As a result, the **frontend and overall user experience (UX/UI)** were not the primary focus in this version.  

Planned improvements for future releases include:  
- A more modern and user-friendly interface  
- Improved navigation and visual design   
- Interactive elements and better accessibility support  
- Streamlined theme customization options  

These enhancements will make the system not only **powerful in functionality** but also **intuitive and enjoyable to use**.  


---
## Author
Thais Guide

---

## Deployment / Live Demo

The **EmployeeM** web application is deployed and accessible online:  

🌐 [EmployeeM Live Demo](https://employeem-webapp-avbebrcqfxd8dbhc.uksouth-01.azurewebsites.net/)  


  
