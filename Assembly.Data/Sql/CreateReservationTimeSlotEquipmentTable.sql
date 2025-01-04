USE GymData;

CREATE TABLE reservation_time_slot_equipment (
    reservation_id INT NOT NULL,
    time_slot_id INT NOT NULL,
    equipment_id INT NOT NULL,
    CONSTRAINT PK_reservation_time_slot_equipment PRIMARY KEY (reservation_id, time_slot_id, equipment_id),
    CONSTRAINT FK_reservation_time_slot_equipment_reservation FOREIGN KEY (reservation_id) REFERENCES reservation(reservation_id),
    CONSTRAINT FK_reservation_time_slot_equipment_time_slot FOREIGN KEY (time_slot_id) REFERENCES time_slot(time_slot_id),
    CONSTRAINT FK_reservation_time_slot_equipment_equipment FOREIGN KEY (equipment_id) REFERENCES equipment(equipment_id)
);
