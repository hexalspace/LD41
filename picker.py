genres = [
"Minesweeper",
"Frogger",
"Pacman",
"Pong",
"Pool",
"Sports",
"Darts",
"Tag",
"Team Based",
"Golf",
"MMORPG",
"OregonTrail",
"Text-based",
"Horror",
"Survival",
"Rougelike",
"Sports",
"Video",
"Game Show",
"Racing",
"Top-down Racer",
"Battle Racer",
"Realistic Racer",
"Card Game",
"CCG",
"Multiplayer",
"Solitaire",
"FPS",
"Walking Simulator",
"Shooter",
"Puzzle",
"Logic",
"Interactive Fiction",
"Story",
"PointAndClick",
"Platformer",
"RPG",
"Fighting",
"Stealth",
"Hack And Slash",
"Side Scroller",
"Tower Defense",
"Visual Novel",
"Third Person",
"Flight Sim",
"Spaceflight Sim",
"Shoot-em-Up",
"Beat-em-Up",
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
"Business",
"Simulation",
"Clicker",
"Battle Royale",
"Artillery",
"Art",
"4X",
"Drawing",
"Indie",
"Casual",
"F2P",
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
"Isometric",
"Board Game",
"Permadeath",
"3D Platformer",
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
"Intentionally Awkward Controls",
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
"Ski-ball",
"Match 3",
"Farming Sim",
"Tennis",
"Grid-based",
"Text Adventure",
"Baseball",
"Mini-games",
"Hockey",
"Swimming",
"Social",
"Skinner Box",
"Ad-based",
"Particle-based"]

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

# ./picker.py Music 10 i s t

import random
import sys

count = 1

newCount = [x for x in sys.argv[1:] if x.isdigit()]
if len(newCount) > 0:
	count = int(newCount[0])

fixedA = [x for x in sys.argv[1:] if len(x) > 1 and not x.isdigit()]
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
	result = "    " # prettier printing start with space
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