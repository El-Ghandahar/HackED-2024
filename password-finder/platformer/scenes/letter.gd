extends Area2D

@onready var label = $Label 
func _on_body_entered(body):
	if body.name == "Player":
		queue_free()
