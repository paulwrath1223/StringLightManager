from tkinter.colorchooser import askcolor
from tkinter import *

root = Tk()
root.title('color configurator')
rgbList = []

from tkinter import *

colorButtons = []
colorSliders = []

menu = Menu(root)
root.config(menu=menu)
filemenu = Menu(menu)
menu.add_cascade(label='File', menu=filemenu)
filemenu.add_command(label='New')
filemenu.add_command(label='Open...')
filemenu.add_command(label='Save...')
filemenu.add_command(label='Save as...')
filemenu.add_separator()
filemenu.add_command(label='Exit', command=root.quit)
helpmenu = Menu(menu)
menu.add_cascade(label='Help', menu=helpmenu)
helpmenu.add_command(label='About')
frame = Frame(root)
frame.pack()


class Controller:
    def __init__(self, ID, pixelLength):
        self.ID = ID
        self.pixelLength = pixelLength


class Color:
    def __init__(self, r, g, b):
        self.r = r
        self.g = g
        self.b = b

    def GetColor(self, col):
        if col == "r":
            return self.r
        elif col == "g":
            return self.g
        elif col == "b":
            return self.b
        else:
            raise Exception("incorrect call to color")

    def SetColor(self, col, val):
        if col == "r":
            self.r = val
        elif col == "g":
            self.g = val
        elif col == "b":
            self.b = val
        else:
            raise Exception("incorrect call to color")


running = True


def done():
    global running
    running = False


def addColor():
    rgbList.append((askcolor(title="Pick a color"))[0])
    colorButtons.append(Button(root, text='Change color').pack())
    colorSliders.append(Scale(root, from_=0, to=200, orient=HORIZONTAL).pack())

    root.mainloop()


button = Button(root, text='Add color', command=addColor)
button.pack()


root.mainloop()

# Info:
# https://www.geeksforgeeks.org/python-gui-tkinter/
# https://www.geeksforgeeks.org/change-the-color-of-certain-words-in-the-tkinter-text-widget/
# https://www.w3schools.com/python/python_json.asp
# https://console.firebase.google.com/u/0/project/light-data1/database/light-data1-default-rtdb/data
# https://morioh.com/p/4dca3ded4cea
