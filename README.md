# MovieListing
This Project concentrates on Creating MoviesList and Adding Producers, Actors etc., It resembles IMDB Website scenario.

# To run this Project:

1. Firstly Create A Database With the help of Provided DBScript in the project, 
2. Create tables and before adding references, include some test data by inserting sample info in to the table which is already given in the DBScript.
3. In Movies Table, add sample data including with ActorID and ProducerID. For this you need to make sure that you have added data for Actors and Producers on Actor table and Producer table. Otherwise Actor and Producer Name wont be appeared on Index Page along with Movie details.
4. Modify required web.config file based on your MSSQL Configuration.
5. This Project runs with a layout page so that we can select and navigate based on the requirement and can be controlled from single screen.

# Validations used in this Project:

1. User to enter Alphabets and/or Special Characters along with Spacing between the Name for example Abhishek Duppati in the Name with Minumum 2 Characters and Maximum of 50

        Regular Expression: /^[a-zA-Z0-9 !@#$%^&*()_+\-=\[\]{};':\\|,.<>\/?]{2,50}$/

        Field Name: Name

2. User to Select the Date in the DD/MM/YYYY Format

        Regular Expression: /(^(((0[1-9]|1[0-9]|2[0-8])[\/](0[1-9]|1[012]))|((29|30|31)[\/](0[13578]|1[02]))|((29|30)[\/](0[4,6,9]|11)))[\/](19|[2-9][0-9])\d\d$)|(^29[\/]02[\/](19|[2-9][0-9])(00|04|08|12|16|20|24|28|32|36|40|44|48|52|56|60|64|68|72|76|80|84|88|92|96)$)/

        Field Name: Year of Release
        
3. Required Field Validator

        Field Name's: Name, Sex, DOB, Bio, YearOfRelease, Plot
        
# To be Added in Future:

1. As ActorID and ProducerID are Primary Key based with References and which are binded to Actors and Movies tables, due to this we cannot put an Edit option for Actor and Producer on Movie index View. Even if we include Edit option and try to do some modifications this only adds a new Actor details or Producer details to the respective tables, because some workarounds needs to be done and Overcome this problem in future.
2. We can try to achieve this using ViewModels but doing CRUD Operations on ViewModel is Challengeable and needs to be concentrated in future.
