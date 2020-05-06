f = open("E:/UnityProjects/KhmerSupport/Assets/KhmerFontAdjuster/consonants.txt","r", encoding="utf8")
Lines = f.readlines()

count = 0
# Strips the newline character
for original in Lines:
	s = original.strip()
	for subLine in Lines:
		s += " " + original.strip() + "្" + subLine.strip()
	print (s)