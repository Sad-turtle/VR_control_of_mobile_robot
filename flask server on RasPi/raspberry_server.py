#Modified by sad_turtle01
#Date: 26.08.2022
# import the necessary packages
from flask import Flask, render_template, Response, request
from camera import VideoCamera
import time
import threading
import os
from robot_control import *


pi_camera = VideoCamera(flip=False) 

app = Flask(__name__)
robot = robot()

@app.route('/')
def index():
    return render_template('index.html') 

@app.route("/car/turn/<direction>")
def turn(direction):
    if direction == "left":
        robot.turn_left()
    elif direction == "right":
        robot.turn_right()
    elif direction == "straight":
        robot.stop()
    return f"{direction}"
@app.route("/car/throttle")
def throttle():
    robot.move_forward()
    return "success throttle"

@app.route("/car/stop")
def stop_car():
    robot.stop()
    return "you stopped the car"

@app.route("/car/reverse")
def reverse_car():
    robot.move_reverse()
    return "you are moving backwards"

@app.route("/car/kill")
def terminate():
    robot.terminate()
    print("robot is turned off")

@app.route('/stream.jpg')
def live_stream():
    frame = pi_camera.get_frame()
    response = Response(frame)
    return response


if (__name__ == '__main__'):
    app.run(host='192.168.0.6', debug=False)
    

