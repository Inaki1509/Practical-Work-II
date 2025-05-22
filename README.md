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
In here, the user can enter numbers and letters from A-F (for hexadecimal to decimal) to introduce what is going to be converted. This is done by using the same actuator for every button, but then defining a different text for each one, and then adding this text to the entry. In the case of the minus, the program makes sure that the digit beggins with a minuus, because it wouldnt be valid if it does not; and for the AC, the program simply clears the entry using string.Clear. After this, the user selects the desired conversion and I decided for simplicity to create a different event actuator for each conversion.  The Conversor page initializes both a Conversor and an Operation List. 
Then, for each of the actuators, the cs file defines an input variable as the text of the entry, and then an output in which it calls the PerformConversion Method of the Converter class but with a different option in every actuator to rech every conversion and using a try catch in order to identify errors in the format of the input. PerformConversion then validates the input in each case, using the validate method (which is overrided for every conversion using a different method). If an error is found, then it is catched by the validate method and passed as a Format Exception. The ConverterPage then proceeds to display an alert for this exception using the message provided, but also leaves another catch to identify other potential errors. Finally, if the input was in the correct format, the conversion is performed and the resulting output is redirected at the entry. Then, even if an error was identified, the resulting operation is added to the operation List using the AddOperations method and to the csv file using the SaveOperations method using a StreamWritter(both methods defined in Operations)
Finally, at the top there are three buttons, one to redirect the user to the operations page, one to Logout and one to Exit. In the operations page, there is a StremReader that reads and displays all the information of the csv file, including the Username, Password and the Operations performed.

The class diagram that descrives the behaviour of the solution is located at tye ExtraFiles folder 

# Class Diagram
![Captura](https://github.com/user-attachments/assets/7ca97413-4c38-47ba-91d5-d721ad5cd787)

## 3. Development Problems
During development, one of the most challenging parts was managing all of the alerts of the system. I did a lot of research to manage the conclusion that the method in which the alert is called must be async, which stands for asynchronous and causes the method itself to run normally until it reaches the await keyword, after which it is suspended until a task is completed, in this case accepting the alert with the keyword OK.
Another important challenge was managing to apply all of the code behind the logic of the Passwords and email requirements in order to proove if they have the correct format. I ended up using a Regex which is a class that stands for Regular Expression. Using the .IsMatch argument, it checks weather the email or password provided matches a description provided as a pattern. This pattern is constructed using special characters such as @^ which in term create the desired pattern.
Managing all the different StreamWriters and StreamReaders prooved to be very challenging, in particular considering all of the try and catches and exceptions that needed to be considered. Particularly, it was very difficult o manage each conversion to print the operation in the csv file, and then reading this file again for the OperationsPage. The code behind the ConversorPage conversions ended up being way more redundant and complicated than I expected, but I couldnt figure out a way to simplify it.


## 4. Conclusions
During the development of this practice, I learned how to create a Graphical User Interface with controlers, pages, layouts and actuators, using .Net Maui and the App Shell Architecture. Moreover, I learned how to implement a code solution that uses the terminal in a graphical interface. I learned how to create a Log In and Sign Up system ans everything it implies, as well as how to control the users inputs for a password and email using RegEx. I know understand the entire process behind a log in system.
I also developed my knowledge about C# development as a whole, in terms of Composition, Inheritance and Polimorphism. Lastly, my solution is probably not the most efficient in terms of use and allocation of resources, particlarly in certain aspects such as when calling the PerformConversion method. However it manages to crate a coherent graphical user interface with working logic and navigation. For future projects, I will dedicate more time into designing the execution of code before implementing it, to avoid this redundancy.





