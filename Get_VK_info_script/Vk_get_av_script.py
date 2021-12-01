import vk_api
from vk_api.longpoll import VkLongPoll, VkEventType
import json
import requests
import sys
import os


TOKEN = ""
with open("TOKEN_VK.info") as f:
	TOKEN = f.readline().strip()
directory = os.path.join("C:\\\\Users\\", os.environ.get("USERNAME"), "Desktop")
#user_id = 452798672
#user_id = 69737824
ALL_IDS = []
try:
	if sys.argv[1] == '-r':
		directory = sys.argv[2]
	if sys.argv[1] == '-m' or (sys.argv[1] == '-r' and sys.argv[3] == '-m'):
		for i in range(sys.argv.index('-m')+1, len(sys.argv)):
			ALL_IDS.append(sys.argv[i])
	if sys.argv[1] == '-f' or (sys.argv[1] == '-r' and sys.argv[3] == '-f'):
		with open(sys.argv[sys.argv.index('-f')+1]) as f:
			ALL_IDS = f.readlines();
			ALL_IDS = [x.strip() for x in ALL_IDS]
except IndexError:
	print("Wrong parametrization")
	sys.exit(1)

img_filename = os.path.join(directory, "Photo_")
info_filename = os.path.join(directory, "Info_")

for user_id_str in ALL_IDS:
	user_id = int(user_id_str)

	bh = vk_api.VkApi(token = TOKEN)
	give = bh.get_api()
	longpoll = VkLongPoll(bh)
	
	try:
		answer_photo = bh.method("users.get", {"user_ids": user_id, "fields": "photo_400"})
		photo_url = answer_photo[0]["photo_400"]
	except BaseException:
		tttemp = 1

	response = requests.get(photo_url)
	if response.status_code == 200:
		with open(img_filename+str(user_id)+".jpg",'wb') as imgFile:
			imgFile.write(response.content)

	answer_info = bh.method("users.get", {"user_ids": user_id, "fields": "first_name, last_name, sex, bdate, country, city, interests, occupation"})
	answer_info = answer_info[0]
	info_to_write = {int(answer_info["id"]):{}}
	if "first_name" in answer_info.keys():
		info_to_write[user_id]["name"] = answer_info["first_name"]
	if "last_name" in answer_info.keys():
		info_to_write[user_id]["surname"] = answer_info["last_name"]
	if "bdate" in answer_info.keys():
		info_to_write[user_id]["bdate"] = answer_info["bdate"]
	if "country" in answer_info.keys():
		info_to_write[user_id]["country"] = answer_info["country"]["title"]
	if "city" in answer_info.keys():
		info_to_write[user_id]["city"] = answer_info["city"]["title"]
	if "interests" in answer_info.keys():
		info_to_write[user_id]["interests"] = answer_info["interests"]
	
	if "occupation" in answer_info.keys():
		if answer_info["occupation"]["type"] == "work":
			info_to_write[user_id]["type"] = "Adult";
			info_to_write[user_id]["work"] = answer_info["occupation"]["name"];

		if answer_info["occupation"]["type"] == "university":
			info_to_write[user_id]["type"] = "Student";
			info_to_write[user_id]["university"] = answer_info["occupation"]["name"];

		if answer_info["occupation"]["type"] == "school":
			info_to_write[user_id]["type"] = "Pupil";
			info_to_write[user_id]["school"] = answer_info["occupation"]["name"];
	try:
		with open(info_filename+str(user_id)+".json", 'w+') as infoFile:
			infoFile.write(json.dumps(info_to_write, ensure_ascii = False))
	except BaseException:
		fictive = 0
sys.exit(0)
