# Introduction

You are working on an auction platform. The service provides its users the ability to post items and search auctions. The company has to implement a privacy policy, where personal data like email addresses, Skype usernames, or phone numbers must be anonymized. 

# Task definition

Your task is to implement 3 content anonymizers:

* For emails (anonymize whole username, leave domain)
* For Skype username (anonymize whole username, leave HTML around if given)
* For phone numbers (anonymize last X digits, leave the remaining digits and country code unchanged)

To complete this task you must:

* Implement methods marked with a `@todo` annotation in the *Anonymizer class
* Check if all anynomizers are valid in the Anonymizer interface context

# Input structure

## Emails

Examples:

* a@a.com
* aa@aa.aa.com
* aa12@aa12.aa.com
* A-A@A-A.com
* A.A@A_A.com

Rules:

* Characters: a-z, A-Z, 0-9, ., _, -
* The first and last character of the username/domain must be a-z, A-Z or 0-9 character

To keep things simple, you do not have to implement RFC standards.

## Skype usernames

Examples:

* skype:username
* skype:USERNAME
* <a href="skype:USERNAME?call">call me</a>

Rules:

* Characters: a-z, A-Z, 0-9

## Phone numbers

To keep things simple, you can assume that all phone numbers are formatted the same way.

Examples:

* +48 444 555 666
* +234 777 888 999
* 321 235 241

Rules:

* The country code is optional (if present, first set of digits is preceded by a + sign)
* The number contains 9 digits in 3 groups, 3 digits each, separated by spaces
* If the number of digits indicates that the country code will be replaced(if present) or if the number of digits in the actual phone number is exceeded, leave the country code intact and replace only the remaining 9 digits

# Hints

Think about invalid types of input that can be passed to the application (and/or database) and protect against them:

* If somebody tries to use a null string as a replacement string, treat it as an empty string
* If somebody tries to anonymize a string that consists of only whitespace characters, treat it as an empty string. Remember that there are many different types of whitespace characters
* If somebody tries to anonymize a null string, throw ArgumentNullException