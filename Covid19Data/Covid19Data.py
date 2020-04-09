
#import pandas
#import pyodbc

#conn = pyodbc.connect('Driver={SQL Server};'
#                      'Server={ServerName};'
#                      'Database=Covid19;'
#                      'Trusted_Connection=yes;')

#cursor = conn.cursor()
#df = pandas.read_csv('time_series_covid19_confirmed_global.csv')
#df.index.names = ["index"]
#dfList = []
##for i in df:
##    dfList.append(i)
##print(df)
##print(dfList[77])
#df = df.loc[0:, 'Country/Region':'Long']
#SQLCommand = 'INSERT INTO CountryInfo(Country,Lat,Long) VALUES (?,?,?)'
#for i in range(0,259):
#    Values = [df.loc[i]["Country/Region"],df.loc[i]["Lat"],df.loc[i]["Long"]]
#    cursor.execute(SQLCommand,Values)
#conn.commit()
    
##print(df.loc[0])
#conn.close()


#import pandas
#import pyodbc
#import numpy as np
#from datetime import datetime
#conn = pyodbc.connect('Driver={SQL Server};'
#                      'Server={ServerName};'
#                      'Database=Covid19;'
#                      'Trusted_Connection=yes;')

#cursor = conn.cursor()
#df = pandas.read_csv('time_series_covid19_confirmed_global.csv')
#df.index.names = ["index"]
#df.fillna('', inplace=True)
#dfList = []
#for i in df:
#    dfList.append(i)
#dfList=dfList[4:]
#SQLCommand = 'INSERT INTO ConfirmTable(Province,Country,Date,TotalCase) VALUES (?,?,?,?)'
#for i in range(0,len(df)):
#    for j in dfList:
#        datetime_object = datetime.strptime(j, '%m/%d/%y')
#        data = np.float32(df.loc[i][j]).item()
#        if data<0:
#            data = 0
#        Values = [df.loc[i][0],df.loc[i][1],datetime_object,data]
#        cursor.execute(SQLCommand,Values)
#conn.commit()
#conn.close()



#import pandas
#import pyodbc
#import numpy as np
#from datetime import datetime
#conn = pyodbc.connect('Driver={SQL Server};'
#                      'Server={ServerName};'
#                      'Database=Covid19;'
#                      'Trusted_Connection=yes;')

#cursor = conn.cursor()
#df = pandas.read_csv('time_series_covid19_deaths_global.csv')
#df.index.names = ["index"]
#df.fillna('', inplace=True)
#dfList = []
#for i in df:
#    dfList.append(i)
#dfList=dfList[4:]
#SQLCommand = 'INSERT INTO DeathTable(Province,Country,Date,Death) VALUES (?,?,?,?)'
#for i in range(0,len(df)):
#    for j in dfList:
#        datetime_object = datetime.strptime(j, '%m/%d/%y')
#        data = np.float32(df.loc[i][j]).item()
#        if data<0:
#            data = 0
#        Values = [df.loc[i][0],df.loc[i][1],datetime_object,data]
#        cursor.execute(SQLCommand,Values)
#conn.commit()
#conn.close()



#import pandas
#import pyodbc
#import numpy as np
#from datetime import datetime
#conn = pyodbc.connect('Driver={SQL Server};'
#                      'Server={ServerName};'
#                      'Database=Covid19;'
#                      'Trusted_Connection=yes;')

#cursor = conn.cursor()
#df = pandas.read_csv('time_series_covid19_recovered_global.csv')
#df.index.names = ["index"]
#df.fillna('', inplace=True)
#dfList = []
#for i in df:
#    dfList.append(i)
#dfList=dfList[4:]
#SQLCommand = 'INSERT INTO RecoveredTable(Province,Country,Date,Recovered) VALUES (?,?,?,?)'
#for i in range(0,len(df)):
#    for j in dfList:
#        datetime_object = datetime.strptime(j, '%m/%d/%y')
#        data = np.float32(df.loc[i][j]).item()
#        if data<0:
#            data = 0
#        Values = [df.loc[i][0],df.loc[i][1],datetime_object,data]
#        cursor.execute(SQLCommand,Values)
#conn.commit()
#conn.close()


#import pyodbc
#import GetOldTweets3 as got

#conn = pyodbc.connect('Driver={SQL Server};'
#                      'Server={ServerName};'
#                      'Database=Covid19;'
#                      'Trusted_Connection=yes;')
#print("Db bağlantısı yapıldı")

#cursor = conn.cursor()

#n = 100
#usernameList = []

#usernameList.append("RTErdogan")
#usernameList.append("drfahrettinkoca")
#usernameList.append("kilicdarogluk")
#usernameList.append("ekrem_imamoglu")
#usernameList.append("mansuryavas06")
#usernameList.append("realDonaldTrump")
#usernameList.append("BorisJohnson")
#usernameList.append("EmmanuelMacron")
#usernameList.append("WHO")

#since = "2020-03-11"
#until = "2020-04-09"


#for user in usernameList:
#    print("user: "+user)
#    tweetCriteria = got.manager.TweetCriteria().setUsername(user)\
#                                               .setSince(since)\
#                                               .setUntil(until)\
#                                               .setMaxTweets(n)
#    tweet = got.manager.TweetManager.getTweets(tweetCriteria)
#    SQLCommand = 'INSERT INTO TweetDataTable(username,tweet,date,favorites,retweets,link) VALUES (?,?,?,?,?,?)'
#    for i in range(len(tweet)):
#        twt = tweet[i]
#        Values = [user,twt.text,twt.date,twt.favorites,twt.retweets,twt.permalink]
#        cursor.execute(SQLCommand,Values)
#    print(" bitti")
#conn.commit()
#conn.close()