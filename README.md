# UnityGame

UnityGame is a open source school project created by students studying at the deparment of informatics at Lunds univsity. the game is called Vetrarbrautin, a space 2d shooter game currently in development.


## Todo
- [x] Create account
- [x] Sign in
- [x] Choose number of players
- [ ] Generate a secutrity token at login in the game. Create a table in database saving the last token used by the user. After we require this token to comfirm that the user is contacting the API from within the game. Right now you can create both rounds and api directly from the browser.
- [ ] encryption:

#### Encryption will have three parts  (key 1)</b>
- shared key, in both client and API
- IV, (random key) generated by the API and sent to client before request is made by Client
- data, the data to encrypt

#### Encryption (key2)
 - Secret key in API creating a hash from password to store in DB
<pre>
------               -----------------             --------------
| DB | ------------- |      API      | ----------- |   Client   |
------               -----------------             --------------
Stored               Generate IV (key1)            Get IV from API(key1)
Hashed               Shared Key (key1)             Shared key (key1)
Password             Data (key1)                   Data (key1)
                     Encrypt hash (key2)
                     Key 2 exclusive for API
</pre>

## API Endpoint

Currenty at v2:

#### Endpoints

- Base URL: http://81.186.252.203/webservice/api.php
- Parameters
 - Version (*)
 - Operation (*)
 - Parameter 1 (optional)
 - Parameter 2 (optional)
 - Parameter 3 (optional)
 - Parameter 4 (optional)
 - and so on...
    
Example request with version and operation without parameter: 

http://81.186.252.203/webservice/api.php/v1/findUserByUsername

Example request with optional parameters

http://81.186.252.203/webservice/api.php/v1/findUserByUsername/Dahlan1337

#### Avaliable Functions and their parameters
- createRound
     - username
     - Score
     - Duration
     - Coins
     
<b>Example request: </b>http://81.186.252.203/webservice/api.php/v2/createRound/Dahlan1337/500/300/200

- findUserByUsername
     - username
     
<b>Example request: </b>http://81.186.252.203/webservice/api.php/v2/findUserByUsername/Dahlan1337

- findUserUpgrades
     - username
     
<b>Example request: </b>http://81.186.252.203/webservice/api.php/v2/findUserUpgrades/Dahlan1337

- findUserRounds
     - username
     
<b>Example request: </b>http://81.186.252.203/webservice/api.php/v2/findUserRounds/Dahlan1337

- createUser
     - username
     - Hash
  
<b>Example request: </b>http://81.186.252.203/webservice/api.php/v2/createUser/Username/Hash

- getAllUpgrades
   - no parameters
   
 <b>Example request: </b>http://81.186.252.203/webservice/api.php/v2/getAllUpgrades
