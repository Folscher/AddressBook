# AddressBook

Hey Brett,

The architecture I went with is a bit overkill for the size of the application. But its just something small to show you how I would tackle a new project.

# A very quick summary

The back end projects consists of Data, Services, Common, Test, Model. Each are seperated to decouple the solution as much as possible. You'll also notice I went with a repository pattern.

The front end projects consists of Web and Wpf. I just added the WPF project in there to illustrate the benefits of having your back end decoupled. Its empty so dont open it :P.

# Break down

# 1. Data
 - Contains my EF code first db context and Generic repositories. You can also add any other for of data connections(like ORM's)
 - Data errors are thrown out of this level

# 2. Service
 - Contains all my services as well as a Generic service class. I use the generic service class compliment the depenency injection            container.
 - Service classes contains all my business logic(validations, calculations ect). I seperate the logic for reusability.
 - All business errors are thrown from here
 
 # 3. Common
  - Contains anything that need to be used across the solution. Things like enums, custom exceptions, extention methods ect.
  
 # 4. Model
  - You can argue that the model should be included in the Data project as it only contains the data models. But I seperate them to decrease dependency on the context. I want to keep the refereces to my db context to a minimum.

 # 5. Test
  - The is where I will write my unit tests. Mainly testing my services as it contains the application business logic.
  - This project is empty. Its just for illustration purposes
  
 # 6. API
  - I like to keep my API as minimalistic as possible. 
  - Send receive data from client
  - Authorization and authentication
  - Error handling
  - Middleware interaction if necessary.
  - No data or business logic should be done here.
  
 # 7. Web
  - If you clone this just make sure the agnular CLI node package is installed on the Angular folder. Otherwise angular wont build. But I dont think its necessary as it just launchces the angular start screen. I haven't done anything it in UI.
  - React folder is empty. I was planning on getting a react front end going aswell, but I dont want to keep you guys waiting forever.
 
 # 8. WPF
  - This is an empty project. Its just illustrates the benefit of the seperated architecture.
  
