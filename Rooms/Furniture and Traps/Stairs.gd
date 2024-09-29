extends Area2D

@onready var collision_shape: CollisionShape2D = get_node("CollisionShape2D")

func _on_Stairs_body_entered(_body: CharacterBody2D) -> void:
	collision_shape.set_deferred("disabled", true)
	SceneTransistor.start_transition_to("res://scenes/Game.tscn")
