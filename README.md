# Practical-Work-II

## Design Detailed Document

## Table of Contents
# 1. Introduction
# 2. Description
# 3. Problems
# 4. Conclusions


## 1. Introduction
This documents presents a solution for a number calculator that is able to make different conversions between different numerical bases and systems. In particular, it is able to convert numbers between decimal to binary, hezadecimal, octal, and Binary Two Complement, and viceversa. It does this by using the .Net Maui architecture and a View Model View Model to produce both a navigable user interface as well as the code behind this interface. This solution was made using Visual Studio Code and the Net MAUI extension as well as an App Shell infrastructure

## 2. Description
The specific behaviour behind this solution goes as follows. The Main page was renamed as LogIn page, and is the beggining of the project where compilation starts. Every page has an image of the UFV logo at the top which serves as a redirect to the LogIn page. From the interface page (xaml), there are two entries in which the user must enter his username and password. In the code behind page (xaml.cs) the behavour of the entries is applied, and the system searches for those particular username and password in a database which is a csv file (User_Info.csv) in the ExtraFiles folder. This logic applies to every single page of the solution. The LogIn page also has two texts that redirect the user to either a PasswordRecovery page where he can enter a valid email (assured with the csv file) to recover his password; and a SignUp page where he can Sign Up with a username, email, password (and confirmation) as well as a checkbox to accept the Privacy Policy. 
This redirections is done using the App Shell, and because of this, the methods tha contain them must be declared as async and contain the await keyword (with which the system knows when to redirect) and nameof (to know where to redirect). This is also used for displaying alerts across every page, which are defined in the code behind page. In the SignUp code behindpage, the system makes sure that the email entered is valid and that the password has at least 8 characters, one uppercase, one lowercase, one number and a special character, as well as the logic that assures that the privacy policy checkbox is marked and tha the username and password are different. After this, it uploads the username and password, as well as a placeholder for the number of operations, to the same csv file used in LogIn. After redirecting to LogIn, the user can know log in into the conversor itself.
In here, the user can enter numbers and letters from A-F (for hexadecimal to decimal) to introduce what is going to be converted. This is done by using the same actuator for every button, but then defining a different text for each one, and then adding this text to the entry. In the case of the minus, the program makes sure that the digit beggins with a minuus, because it wouldnt be valid if it does not; and for the AC, the program simply clears the entry using strin.





![alt text]("./ExtraFiles/Captura.png")

