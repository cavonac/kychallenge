# WPF-Example
##### by Christopher Canova
## From the interviewer:
As part of our interview process, I’d like to ask you to send me software code with unit tests so I could assess your skills. Please respond within approximately 48 hours.  __Please make sure that the code does not violate your confidentiality obligations to your former or current employer which probably prohibits you from sharing the code with outside parties.__ Please send your code for review, not spending more than a few hours, through GitHub (preferred) or zip file over email (or contact me if you would like to use an alternative).
<br/><br/>
Here is the requirement list of metrics that we are using it for code review:

- Readability/Maintainability/Testability
- Safe concurrency
- OOP/SOLID principals 
- Project layout/organization
<br/><br/>
An expected time to complete this would be about 1 hour.
<br/><br/>
Write a C# .NET GUI application that meets the following requirements:
<br/><br/>
- WPF or WinForms
- Contains a background thread that simply keeps track of the number of seconds that have passed since the application started.
  - Integer precision fine
  - This thread should not block the operation of the main UI thread.
  - **Note:** I’m specifically looking for a solution utilizing a thread.
- Contains the following controls on the user interface:
  - A display of the number of seconds since application start
  - A button that allows resetting the number of seconds since application start to zero
  - A text box that allows the user to specify an arbitrary integer value, and a button that immediately sets the timer to that value.
  - A text box that contains a number and a button that increments that number each time the button is pressed.
- Ensure that user input is properly validated.
- Unit tests exist for code that is unit testable.
<br/><br/>
Also: Include a description of alternative way(s) of implementing a timer like this that does not use another thread, but that also does not block the UI or cause other concurrency problems.
---
# Solution
The best way to keep a timer on a different thread from the WPF application is:
- DispatcherTimer object
  - Increments a variable that can be databound
  - Use the Tick event
  - Works on the Dispatcher queue thread and not the UI's thread
- It must be implemented using code-behind to update a variable that is data-bound to the UI
- Reset or update buttons will update the variable to 0
- If properly data bound, any changes to variables ought to be displayed properly
- Since validation is on a single input, I did not choose to implement the interfaces that notify on error
  - Instead, I choose to display an error message in a dialog (being careful not to reflect the data)
  - It performs a int.TryParse on the text when the button is clicked

As far as implementing a solution without using another thread, a possible solution would be to manage everything with try/catch blocks on the input but this could get bulky. I do not recommend creating automated tests for WPF application until there are some library classes created. Instead, test manually.

## UI Manual Test Cases
1. Does the application display an integer value representing the number of seconds since application start?
2. Does the timer increment each second, starting from 0?
3. Is there a reset button that when clicked resets the seconds timer to 0?
4. Is there a text box for inputting a new integer count on the seconds timer?
5. Is the text box input validated when the set timer button is clicked with an invalid string?
6. Does the set timer button set the seconds timer to valid integer values?
7. Is there a counter displayed that starts at 0?
8. Is there a button to increment the counter when clicked?
9. Does the UI not hang or crash during testing?
10. Does the UI appear intuitive or has label text around functional aspects?
11. Is the UI clean and easy to understand for non-expert users?
12. Does the set timer text box work with negative values?
13. The UI does not crash or hang when rapidly clicking the increment counter or reset buttons 
