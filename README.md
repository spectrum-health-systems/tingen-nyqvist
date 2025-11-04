# Tingen NYQVIST

## Installing

1. Download the [latest release](https://github.com/spectrum-health-systems/tingen-nyqvist/releases)
2. Extract the .7z file to a location of your choice
3. Double click `TingenNYQVIST.exe`

## Using

![](/.github/readme/mainwindow.png)

Username  
• Must be a valid Avatar Username that has access to run SQL queries against an Avatar System.  
• You can either enter this manually when you use NYQVIST, or you can put a valid username in the AppData/Config/nyqvist.username file.  

Password  
• The password for the provided Username.

Query  
• The SQL query you want to run against an Avatar System.

For example:  
`SELECT USERROLE FROM RADplus_users WHERE 'WEB SERVICE ID' = USERID`

System  
• The Avatar System you would like to run the Query against.  
• Each Avatar System is represented by a button. Pressing the button for an Avatar System runs the Query against that Avatar System.  
• The Username and Password must exist/be valid in the Avatar System you choose.  

Result  
• The result of the SQL query, returned as raw XML data.  
• To format the data, press the “Format XML” button.  
• To copy the result to the clipboard, press the “Copy XML” button.

Web Service  
• The web service call that can be used in the Tingen Web Service.  
• To copy the web service call, press the “Copy web service call” button.

Additional information

If you receive this error message:

![](/.github/readme/authentication-error.png)

Verify that the Username and Password exists in the Avatar System you are running the query against, and that they are both valid.
