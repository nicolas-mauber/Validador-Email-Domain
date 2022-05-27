# Validador-Email-Domain

This program is used to validate email domains. It works in two ways. The first method uses processes. These execute the nslook up command in a console that validates domains. Then, the result of the execution of the command is captured and analized to validate the domain. If the domain is valid it returns true.

The other way is executed in the event that the console could not be executed for whatever reason. This method consists of calling an api, capturing its response in JSON format and validating the entered domain.


### U HAVE TO INSERT THE FULL DOMAIN, IF YOU WRITE ONLY GMAIL, IT WILL RETURN FALSE. YOU HAVE TO INSERT GMAIL.COM
