genres = [
"Minesweeper",
"Frogger",
"Pacman",
"Pong",
"Pool",
"Sports",
"Golf",
"MMORPG",
"Oregon Trail",
"Text Based",
"Horror",
"Survival",
"Rougelike",
"Sports",
"Video",
"Game Show",
"Racing",
"Topdown Racer",
"Battle Racer",
"3D Sim Real Racer",
"Card Game",
"CCG",
"Multiplayer",
"Solataire",
"FPS",
"Walking Simulator",
"Shooter",
"Puzzle",
"Logic",
"Interactive Fiction",
"Story",
"Point and Click",
"Platformer",
"Role Playing",
"Fighting",
"Simulation",
"Stealth",
"Hack And Slash",
"Side Scroller",
"Tower Defense",
"Visual Novel",
"THird Person",
"Flight Sim",
"Space Flight Sim",
"Shoot em Up",
"Beat em Up",
"Open World",
"Rhythm",
"Nonviolent",
"Music",
"God Game",
"Falling Sand",
"Dungeon Crawl",
"Dating",
"Management",
"City Builder",
"Browser",
"Business Simualation",
"Clicker",
"Battle Royale",
"Artillery",
"Art",
"4X",
"Drawing",
"Indie Casual",
"Free 2 Play",
"Atmospheric",
"Difficult",
"Co-op",
"Pixel",
"Sandbox",
"Arcade",
"Turn Based",
"Exploration",
"Education",
"PvP",
"RTS",
"BulletHell",
"Minimalist",
"Procedural",
"ISometric",
"Board Game",
"Permadeath",
"3d Platformer",
"Metroidvania",
"Economy",
"Detective",
"Linear",
"Voxel",
"CRPG",
"Score Attack",
"Hunting",
"Quicktime Events",
"Heist",
"Historical",
"Football",
"Soccer",
"Programming",
"Sailing",
"VR",
"Typing",
"Intentionally Awkward Contrals",
"Bikes",
"Spelling",
"Choices Matter",
"Time",
"Light Gun Shooter",
"Aliens",
"Asteroids",
"Chess",
"Go",
"Marble",
"Pinball",
"Basketball",
"Skiball" ]

smallerGenreList = [
"Music",
"FPS",
"Spelling",
"Racing",
"Platformer",
"Interactive Fiction",
"Card Game",
"Sports",
"Artillery",
"Strategy",
"Rougelike",
"Metroidvania",
"Exploration",
"Puzzle",
"Turn Based"
 ]

# ./picker.py thisArgCodeIsAWFUL

import random
import sys

count = 1

newCount = [x for x in sys.argv[1:] if x.isdigit()]
if len(newCount) > 0:
	count = int(newCount[0])

fixedA = [x for x in sys.argv[1:] if len(x) > 1]
aChanges = True
if len(fixedA) > 0:
	aChanges = False
	a = fixedA[0]

shouldInvertOrder = False
if 'i' in sys.argv:
	shouldInvertOrder = True

genreList = genres
if 's' in sys.argv:
	genreList = smallerGenreList

thirdGenre = False
if 't' in sys.argv:
	thirdGenre = True

for x in range(0, count):
	result = ""
	if aChanges:
		a = random.choice(genreList)
	b = random.choice(genreList)
	if shouldInvertOrder:
		result += b + " " + a
	else:	
		result += a + " " + b
	if thirdGenre:
		result += " " + random.choice(genreList)
	print(result)