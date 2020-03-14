# Easy way to deploy on heroku with one click
[![Deploy to Heroku](https://www.herokucdn.com/deploy/button.png)](https://dashboard.heroku.com/new-app?template=https://github.com/ScarletKuro/NadekoBot-Heroku-Auto-Deploy)(click the button)

**NB!** This will deploy with using heroku's postgresql, if you need mssql use the manual method, if you need to use your custom postgresql its enough to just change the postgresql URI in the enviroments(Settings->Config Vars).


![Don't read abobe](https://i.imgur.com/rcMFZ37.png)

# Below guide is a manual deployment method

## Explanation
Before you continue, notice that this nadeko uses **Microsoft SQL Server** or **PostgreSQL**.
If you are going to use MSSQL then you need to have your **own** SQL Server since heroku doesn't provide any. And for PostgreSQL you can install free/paid plugin in heroku. 
Why it uses remote database instead of the built-in SQLite? The answer is because of heroku's [**ephemeral filesystem.**](https://devcenter.heroku.com/articles/dynos#ephemeral-filesystem)

## Tools That You Need
1. [**GIT**](https://git-scm.com/downloads)
2. [**The Heroku CLI**](https://devcenter.heroku.com/articles/heroku-cli#download-and-install)

## Creating New App In Heroku
1. Log(or make account) in heroku [**dashboard**](https://dashboard.heroku.com)
2. Click on the "New" button in right cornet and select "create new app"
![Image of Creating App](https://i.imgur.com/E097TzF.png)

3. Enter unique app name and select region and click "Create app".
4. Select "Overview" tab and click on "Configure Add-ons".
5. In the search bar enter "Heroku Redis" and select plan(free) and install the plugin.
6. Same again but now enter "LogDNA".
7. *If you are going to use PostgreSQL, then install the "Heroku Postgres" too.* If MSSQL then skip this step.
8. Click on the "Heroku Redis" plugin and after you will be redirected on redis dashboard click "View Credentials..." you will see host, port, user and password. Write them down somewhere, we will need them later.
9. Go back to the main heroku dashboard(click on the app if you are on apps list) go to the "Settings" and add those buildpacks:
   - ```https://github.com/challengee/heroku-buildpack-libsodium```
   - ```https://github.com/jonathanong/heroku-buildpack-ffmpeg-latest.git```
   - ```https://github.com/dubsmash/heroku-buildpack-opus.git```
   - ```https://github.com/appositum/heroku-buildpack-youtube-dl.git```
   - ```https://github.com/ScarletKuro/dotnetcore-buildpackv2.1.git```

	**NB! Watch out for extra spaces when copy-pasting.**



## Setting Up The Database
You have two options here: MSSQL or PostgreSQL.

MSSQL option:
 - In **credentials.json** use following type and connectionstring: 
	```json
	"Type": "sqlserver",
	"ConnectionString": "Data Source={address to database};Initial Catalog={database name};User ID={username};Password={password}"
	```

PostgreSQL option:
 - For using PostgreSQL  you need to have "Heroku Postgres" plugin installed on your dyno. Remember that if you are using free plan you have only *10000 rows* available.
 - In **credentials.json** use following type and connectionstring: 
	```json
	"Type": "pgsql",
    "ConnectionString": "Host={address to database};Port={port};Database={database name};Username={username};Password={password};SSL Mode=Require;Trust Server Certificate=true;Maximum Pool Size=20;Keepalive=60"
	```
<span style="color:red">Only edit the parameters in {} brackets, don't touch the rest if you don't know what you are doing.</span>

 **NB!** *If you are using a domain name to connect to database take a note that some domain names may require a **www** prefix and some doesn't to connect to the database.
	For example my college SQL Server needs a *www* before the domain name and the gearhost's doesn't as well as heroku postgresql.*


To connect to your database I recommend to use [**Database.NET**](https://fishcodelib.com/files/DatabaseNet4.zip) it's a light tool and supports connection for both MSSQL and PostgreSQL databases.

## Setting Up The Nadeko
1. On my github go to to the [**release**](https://github.com/ScarletKuro/NadekoBot/releases) and download the **heroku-nadeko-1.9-release.zip**(not the Source code or anything else)
	
	![Image of Realse](https://i.imgur.com/J4ZQgTW.png)
2. Extract the zip archive in a folder
3. Edit the **credentials.json** the explanation is located [**here**](https://nadekobot.readthedocs.io/en/latest/JSON%20Explanations/#setting-up-credentialsjson-file). But we will need to edit the RedisOptions as well. **{Host}**:**{Port}**, name=**{User}**, password=**{Password}** replace them with credentials from Heroku Redis Dasboard(remove the {} brackets).
![Image of RedisOptions](https://i.imgur.com/dipJaQg.png)
And the ConnectionString and Type for Database as well, look at the "Setting Up The Database" section.
4. Save

## Deploying To Heroku
Open Your PC terminal and type those commands:

1. ```cd <directory to the nadekobot where you extracted the archieve>```
2. ```heroku login``` and enter your heroku credentials
3. ```git init```
4. ```heroku git:remote -a <heroku app name>```
5. ```git add .```
6. ```git commit -am "init"```
7. ```git push heroku master```

After the installation is done go to he application dashboard and click "Configure Dynos" click the edit button and toggle the dyno then "Config" button.

![Image of Dyno Toggle](https://i.imgur.com/VqhizUN.png)

Now you can go to the LogDNA and view logs of your nadeko and look what it's doing

FIN.

## Video How To Setup
[![ScreenShot](http://i.imgur.com/PaplNYc.png)](https://www.youtube.com/watch?v=Ld1UPdgxikE)
