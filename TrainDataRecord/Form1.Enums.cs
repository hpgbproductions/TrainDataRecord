namespace TrainDataRecorder
{
    partial class Form1
    {
        /// <summary>
        /// Signals that the recorder should be stopped (RecorderModes.Disabled), or is running in a game (other values).
        /// </summary>
        public enum RecorderModes
        {
            Disabled,
            TrainCrew,
            BVE,
            DerailValley,
        }

        public enum DataField
        {
            time_sim,
            time_elapsed,
            time_tick,
            diagram_trainNumber,
            diagram_boundFor,
            diagram_serviceType,
            diagram_direction,
            diagram_runNumber,
            stations_currentIndex,
            stations_nextIndex,
            stations_next_name,
            stations_next_fromStartDistance,
            stations_next_absoluteDistance,
            stations_next_doorSide,
            stations_next_stopType,
            stations_next_arrival,
            stations_next_departure,
            stations_next_stopPositionName,
            stations_next_trackSectionName,
            stations_next_remarks,
            stations_next_entrySpeed,
            stations_next_exitSpeed,
            stations_next_isTimeTaken,
            physics_speed,
            physics_fromStartDistance,
            physics_absoluteDistance,
            physics_curveRadius,
            physics_gradient,
            physics_mrPressure,
            physics_totalLoadMass,
            controllers_powerNotch,
            controllers_brakeNotch,
            controllers_reverser,
            controllers_ato_active,
            controllers_ato_notch,
            controllers_tasc_active,
            controllers_tasc_notch,
            controllers_tasc_inching,
            controllers_deadman,
            doors_allClosed,
            doors_perCar_carNo,
            doors_perCar_sideOpened,
            lamps_doorClose,
            lamps_atsReady,
            lamps_atsBrakeApply,
            lamps_atsOpen,
            lamps_regenerative,
            lamps_ebTimer,
            lamps_emergencyBrake,
            lamps_overload,
            lamps_ato,
            lamps_snowBrake,
            lamps_wheelSlip,
            ats_class,
            ats_speed,
            ats_state,
            signals_next_name,
            signals_next_type,
            signals_next_phase,
            signals_next_distance,
            speedLimit_current,
            speedLimit_currentType,
            speedLimit_next,
            speedLimit_next_distance,
            speedLimit_next_type,
            cars_carNo,
            cars_bogies_position,
            cars_bogies_bcPressure,
            cars_bogies_amperage,
            cars_occupancyRate,
            cars_loadMass,
            switches_hornAir,
            switches_hornElectric,
            switches_buzzerDriver,
            switches_buzzerConductor,
            switches_headlights,
            switches_highBeam,
            switches_wiper
        }

        /// <summary>Multi-column fields, where the number of columns used = number of cars. </summary>
        public readonly DataField[] PerCarFields =
        {
            DataField.doors_perCar_carNo,
            DataField.doors_perCar_sideOpened,
            DataField.cars_carNo,
            DataField.cars_loadMass,
            DataField.cars_occupancyRate,
        };

        /// <summary>Multi-column fields, where the number of columns used = number of bogies across all cars.</summary>
        public readonly DataField[] PerBogieFields =
        {
            DataField.cars_bogies_amperage,
            DataField.cars_bogies_bcPressure,
            DataField.cars_bogies_position,
        };
    }
}
