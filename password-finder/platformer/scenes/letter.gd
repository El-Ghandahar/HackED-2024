extends Area2D

func _on_letter_body_entered(body):
	(body).coin_collected.emit()
