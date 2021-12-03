import pymysql
from pymysql import connections
from pymysql import cursors
from pymysql.cursors import DictCursor
from contextlib import closing
import sys
import json

connection = pymysql.connect(host = "localhost", user = "root", db = "opd_5group", charset = "utf8", cursorclass = DictCursor)
cursor = connection.cursor()

#Question - string
#Answers - dict (string text, int radical)
def writeQA(question, answers):
	cursor.execute("select count(*) from questions")
	res = cursor.fetchall()
	q_id = int(res[0]["count(*)"]) + 1
	cursor.execute(str('insert into questions (Question_id, Content) values (%d, "%s")'%(q_id, question)))

	cursor.execute("select count(*) from answers")
	res = cursor.fetchall()
	ans_id = int(res[0]["count(*)"]) + 1
	for answer in answers.keys():
		cursor.execute('insert into answers (Answer_id, Question_id, Content, Radical) values (%d, %d, "%s", %d)'%(ans_id, q_id, answer, answers[answer]))
		ans_id += 1
	connection.commit()
def clearEx():
	cursor.execute('delete from answers where Content like "Ex.%"')
	connection.commit()
	cursor.execute('delete from questions where Content like "Examplary%"')
	connection.commit()

def printQATables():
	cursor.execute("select * from questions")
	for cur in cursor:
		print(cur)
	print("\n\n")
	cursor.execute("select * from answers")
	for cur in cursor:
		print(cur)

def main():
	if(len(sys.argv) != 3):
		print("Invalid argumentation!")
		return
	if(sys.argv[1] == '-f'):
		fin = open(sys.argv[2],encoding = "utf-8")
		myData = json.load(fin)
		for cur in myData.keys():
			question_content = myData[cur]["Question"]
			answers = {}
			for ans in myData[cur]["Answers"].keys():
				answers[myData[cur]["Answers"].get(ans)[0]] = myData[cur]["Answers"].get(ans)[1]
			writeQA(question_content, answers)

main()