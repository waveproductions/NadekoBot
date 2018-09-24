## Explanation
Before you continue, notice that this nadeko uses **Microsoft SQL Server** and you need to have your **own** SQL Server since heroku doesn't provide any.
Why it uses MSSQL instead of the built-in SQLite? The answer is because of heroku's [**ephemeral filesystem.**](https://devcenter.heroku.com/articles/dynos#ephemeral-filesystem)

##Tools That You Need
1. [**GIT**](https://git-scm.com/downloads)
2. [**The Heroku CLI**](https://devcenter.heroku.com/articles/heroku-cli#download-and-install)

## Creating New App In Heroku
1. Log(or make account) in heroku [**dashboard**](https://dashboard.heroku.com)
2. Click on the "New" button in right cornet and select "create new app"
![Image of Creating App](https://i.imgur.com/E097TzF.png)

3. Enter unique app name and select region and click "Create app"
4. Select "Overview" tab and click on "Configure Add-ons"
5. In the search bar enter "Heroku Redis" and select plan(free) and install the plugin
6. Same again but now enter "LogDNA"
7. Click on the "Heroku Redis" plugin and after you will be redirected on redis dashboard click "View Credentials..." you will see host, port, user and password. Write them down somewhere, we will need them later.
8.Go back to the main heroku dashboard(click on the app if you are on apps list) go to the "Settings" and add those buildpacks:
 - ```https://github.com/challengee/heroku-buildpack-libsodium```
 - ```https://github.com/jonathanong/heroku-buildpack-ffmpeg-latest.git```
 - ```https://github.com/dubsmash/heroku-buildpack-opus.git```
 - ```https://github.com/appositum/heroku-buildpack-youtube-dl.git```
 - ```https://github.com/ScarletKuro/dotnetcore-buildpackv2.1.git```
**NB! Watch out for extra spaces when copy-pasting.**



## Setting Up The Database
You need MSSQL Server for this bot:

- If you don't have any SQL Server, you can temporary use [**gearhost**](https://www.gearhost.com/). Remember that it has *limited data-size*.
- To connect to your database I recommend [**Database.NET**](https://fishcodelib.com/files/DatabaseNet4.zip)

We need credentials from the database, the url/ip where the database located, user, password and the database name.

## Setting Up The Nadeko
1. On my github go to to the [**release**](https://github.com/ScarletKuro/NadekoBot/releases) and download the **heroku-nadeko-1.9-release.zip**(not the Source code or anything else)
![Image of Realse](https://i.imgur.com/J4ZQgTW.png)
2. Extract the zip archive in a folder
3. Edit the **credentials.json** the explanation is located [**here**](https://nadekobot.readthedocs.io/en/latest/JSON%20Explanations/#setting-up-credentialsjson-file). But we will need to edit the RedisOptions as well. **{Host}**:**{Port}**, name=**{User}**, password=**{Password}** replace them with credentials from Heroku Redis Dasboard(remove the {} brackets).
![Image of RedisOptions](https://i.imgur.com/dipJaQg.png)
And the ConnectionString for Database as well
   
 **NB!** *If you are using a domain name to connect to database take a note that some domain names may require a **www** prefix and some doesn't to connect to the database.
	For example my college SQL Server needs a *www* before the domain name and the gearhost's doesn't.*
4. Save

## Deploying To Heroku
Open Your PC terminal and type those commands:

1. ```cd <directory to the nadekobot where you extracted the archieve>```
2. ```heroku loging``` and enter your heroku credentials
3. ```git init```
4. ```heroku git:remore -a <heroku app name>```
5. ```git add .```
6. ```git commit -am "init"```
7. ```git push heroku master```

After the installation is done go to he application dashboard and click "Configure Dynos" click the edit button and toggle the dyno then "Config" button.

![Image of Dyno Toggle](https://i.imgur.com/VqhizUN.png)

Now you can go to the LogDNA and view logs of your nadeko and look what it's doing

FIN.