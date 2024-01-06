extends CharacterBody2D

@export var speed = 300

func _physics_process(delta):
	var horizontal_direction = Input.get_axis("move_left", "move_right")
	velocity.x = speed * horizontal_direction	
	move_and_slide()
