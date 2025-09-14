# EmployeeM

**EmployeeM** is a web-based system developed with ASP.NET MVC and ADO.NET for efficient employee management. The application includes role-based access control, department-specific theme customization, and secure authentication to streamline administrative tasks while ensuring data integrity and usability.  

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
- **Balsamiq Wireframes** – Created wireframe images of the website (viewable [here](#))  

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
![Initial Step](link-to-your-screenshot1)  

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
![Edit Employee Step](link-to-your-screenshot2)  

**Expected result:** Employee information is updated in the database.  
**Actual result:** Works as intended.  

---

### Test 3: Role-Based Access Verification
*"I would like to ensure department managers cannot access other departments"*

**Actions:**  
- Log in as a Department Manager  
- Try accessing employees from other departments  

**View image of the steps:**  
![Role Test Step](link-to-your-screenshot3)  

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
![Theme Step](link-to-your-screenshot4)  

**Expected result:** Theme is applied dynamically across all pages.  
**Actual result:** Works as intended.  

---

### Test 5: Search & Filter Employees
*"I would like to search for employees by name or ID"*

**Actions:**  
- User types Name or Employee ID into search field  
- Clicks “Search” or filters results  

**View image of the steps:**  
![Search Step](link-to-your-screenshot5)  

**Expected result:** Only relevant employees are displayed.  
**Actual result:** Works as intended.  

---

### Test 6: Authentication
*"I would like to log in to access employee management features"*

**Actions:**  
- User enters credentials on the login page  
- Clicks “Login”  

**View image of the steps:**  
![Login Step](link-to-your-screenshot6)  

**Expected result:** User is redirected to the homepage with proper role-based access.  
**Actual result:** Works as intended.  

---

### Test 7: Mobile Responsiveness
*"I would like to access the system on different devices"*

**Actions:**  
- Open EmployeeM on mobile, tablet, and desktop  
- Check layout and usability  

**View image of the steps:**  
![Responsive Step](link-to-your-screenshot7)  

**Expected result:** Interface adapts to all screen sizes and remains functional.  
**Actual result:** Works as intended.  

> ⚠️ Replace `link-to-your-screenshotX` with actual GitHub-hosted images or URLs of your screenshots.  

---

## Future Improvements

While **EmployeeM** provides full functionality for employee management, role-based access, and department theme customization, it’s important to note that the application **did not focus extensively on user experience (UX) design**.  

Planned improvements include:  

- Enhancing the **user interface** with more intuitive navigation and visually appealing layouts.  
- Improving **mobile and tablet usability** with advanced responsive designs.  
- Adding **interactive feedback** for user actions (e.g., confirmations, alerts, and notifications).  
- Streamlining **theme customization** to make it more user-friendly.  
- Implementing **advanced search and filtering** options for quicker data access.  

These enhancements are part of future development plans to improve **usability, accessibility, and overall user satisfaction**.  

---

## Deployment / Live Demo

The **EmployeeM** web application is deployed and accessible online:  

🌐 [EmployeeM Live Demo](https://employeem-webapp-avbebrcqfxd8dbhc.uksouth-01.azurewebsites.net/)  

To run locally:  
```bash
git clone https://github.com/Thaistg11/EmployeeM.git


---
## Author
Thais Guide  
