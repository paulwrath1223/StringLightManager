"""Stores the Lights value
Class description
"""
class Light:
    mode = 0
    color = (255, 255, 255)
    id = 0
    on = False

    def __init__(self, id_number, mode, color):
        self.mode = mode
        self.color = color
        self.id = id_number

    def __repr__(self):
        return f"Lights{self.id}, mode:{self.mode}, color:{self.color}, turned on:{self.on}"


