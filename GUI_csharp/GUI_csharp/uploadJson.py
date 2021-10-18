# This is a sample Python script.

# Press Shift+F10 to execute it or replace it with your code.
from firebase_admin import db
import firebase_admin
from firebase_admin import credentials
import json

# Opening JSON file
f = open('temp.json', )

# returns JSON object as
# a dictionary
data = json.load(f)

cred = credentials.Certificate("light-data1-firebase-adminsdk-vkdpc-267e01cc58.json")
firebase_admin.initialize_app(cred, {
    'databaseURL' : 'https://light-data1-default-rtdb.firebaseio.com/'
})


root = db.reference()
# Add a new user under /users.
new_user = root.set(data)

f.close()
