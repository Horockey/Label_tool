import pymysql
from pymysql import connections
from pymysql import cursors
from pymysql.cursors import DictCursor
from contextlib import closing
import sys
import json

connection = pymysql.connect(host = "localhost", user = "root", db = "opd_5group", charset = "utf8", cursorclass = DictCursor)
cursor = connection.cursor()

def main():
	if(len(sys.argv) != 3):
		print("Invalid argumentation!")
		return
	if(sys.argv[1] == '-f'):
		fin = open(sys.argv[2])
		data = json.load(fin)
		for curUsername in data.keys():
			cursor.execute('select * from users where User_name = "%s"'%(curUsername))
			res = cursor.fetchall()
			userid = 0
			if(len(res) > 0):
				userid = res[0]["User_ID"]
				#cursor.execute("delete from user_answers where User_ID = %d"%(userid))
			else:
				cursor.execute("select count(*) from users")
				res = cursor.fetchall()
				userid = res[0]["count(*)"] + 1
				cursor.execute("insert into users (User_ID, User_name) values (%d, '%s')"%(userid, curUsername))
			connection.commit()
			j_answers = json.dumps(data[curUsername])
			cursor.execute("select count(*) from user_answers")
			res = cursor.fetchall()
			answerid = res[0]["count(*)"] + 1
			cursor.execute("insert into user_answers (ID, User_ID, Result) values (%d, %d, '%s')"%(answerid, userid, str(j_answers)))
			connection.commit()


main()