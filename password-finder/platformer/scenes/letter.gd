extends Area2D

@export var collectedPoints = 0 
@onready var label = $Label 



func _on_body_entered(body):
	if body.name == "Player":
		emit_signal("area_entered")
		queue_free()
