USE GymData;

INSERT INTO reservation_time_slot_equipment(reservation_id, time_slot_id, equipment_id)
SELECT 
    reservation_id,
	time_slot_id,
    equipment_id
FROM reservation
WHERE time_slot_id IS NOT NULL AND equipment_id IS NOT NULL;

UPDATE reservation
SET time_slot_id = NULL, equipment_id = NULL
WHERE time_slot_id IS NOT NULL AND equipment_id IS NOT NULL;

SELECT * FROM reservation_time_slot_equipment;
