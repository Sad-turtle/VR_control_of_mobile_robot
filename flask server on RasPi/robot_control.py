import RPi.GPIO as gpio
import time
class robot():
    def __init__(self):
        gpio.setmode(gpio.BOARD)
        gpio.setup(15, gpio.OUT)
        gpio.setup(16, gpio.OUT)
        gpio.setup(18, gpio.OUT)
        gpio.setup(22, gpio.OUT)

    def move_reverse(self):
        gpio.output(15, True)
        gpio.output(16, False)
        gpio.output(18, False)
        gpio.output(22, True)
        #time.sleep(tf)
                                                    
    def move_forward(self):
        gpio.output(15, False)
        gpio.output(16, True)
        gpio.output(18, True)
        gpio.output(22, False)
        #time.sleep(tf)
                                                                                
    def turn_left(self):
        gpio.output(15, True)
        gpio.output(16, False)
        gpio.output(18, True)
        gpio.output(22, False)
        #time.sleep(tf)
                                                                                                            
    def turn_right(self):
        gpio.output(15, False)
        gpio.output(16, True)
        gpio.output(18, False)
        gpio.output(22, True)
        #time.sleep(tf)

    def stop(self):
        gpio.output(15, False)
        gpio.output(16, False)
        gpio.output(18, False)
        gpio.output(22, False)
        #time.sleep(tf)
    def terminate(self):
        gpio.output(15, False)
        gpio.output(16, False)
        gpio.output(18, False)
        gpio.output(22, False)
        gpio.cleanup()
