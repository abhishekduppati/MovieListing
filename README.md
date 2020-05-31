# MovieListing
This Project concentrates on Creating MoviesList and Adding Producers, Actors etc., It resembles IMDB Website scenario.

To run this Project:
1. Firstly Create A Database With the help of Provided DBScript in the project, 
2. Create tables and before adding references, include some test data by inserting sample info in to the table which is already given in the DBScript.
3. In Movies Table, add sample data including with ActorID and ProducerID. For this you need to make sure that you have added data for Actors and Producers on Actor table and Producer table. Otherwise Actor and Producer Name wont be appeared on Index Page along with Movie details.
4. Modify required web.config file based on your MSSQL Configuration.
5. This Project runs with a layout page so that we can select and navigate based on the requirement and can be controlled from single screen.
To be Added in Future:
1. As ActorID and ProducerID are Primary Key based with References and which are binded to Actors and Movies tables, due to this we cannot put an Edit option for Actor and Producer on Movie index View. Even if we include Edit option and try to do some modifications this only adds a new Actor details or Producer details to the respective tables, because some workarounds needs to be done and Overcome this problem in future.
2. We can try to achieve this using ViewModels but doing CRUD Operations on ViewModel is Challengeable and needs to be concentrated in future.
