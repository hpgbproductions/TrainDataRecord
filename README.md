# TrainDataRecord

Data logger for TRAIN CREW. Exports train telemetry data in CSV files for later analysis of train and driving performance.

## Credits

Uses libraries for [Rudolf](https://github.com/haruyukitanuki/Rudolf) and the [TrainCrew adapter](https://github.com/haruyukitanuki/Rudolf.Adapters.TrainCrew) by [Haruyuki Tanukiji](https://github.com/haruyukitanuki).

## Step-by-Step Guide

1. Choose the location and name of the CSV file.
	- Type the location in the text box, or click on the "..." button to open the file picker.
	- Use a relative file path (without drive letter) to generate the file in the same folder as the EXE.

> [!CAUTION]
> If the file already exists, **it will be overwritten.** No warning is given if the path is entered using the text box. The file is written when the recording is started. The file is not written if no data channels are selected.

2. Specify the frequency of data reading.
	- The maximum frequency is 10 Hz.
	- Due to CPU timing inaccuracies, the frequency may vary slightly.
	- Timing is done in real time (not game time). Output will be irregular at the point of pausing the game, using fast forward, etc.

3. Choose the number of train cars.
	- This only has an effect when reading per-car data.
	- If the number specified is larger than the actual number of cars, empty columns will be present, but no data will be lost.
	- If the number specified is smaller than the actual number of cars, some train data will be lost.

4. Check your system locale.
	- Enable "European Mode" to change the CSV format for decimal-comma locales.

5. Decide if additional JSON files should be generated.
	- Data frame will be produced at `[file path from step 1].df.json`.
		- Written at the same frequency as data reading.
	- Simulator profile will be produced at `[file path from step 1].sp.json`.
		- Written each time the scenario ID is changed.
	- This is mainly for debugging and studying.
		- No warning will be given for overwriting files.
		- Only the latest data will be available.
		- Realtime changes can be seen in certain programs like VS Code.

6. Add data channels.
	- The panel on the left displays all available data channels.
	- Click on an entry in the left panel to select it. You can use the Ctrl and Shift modifier keys to select multiple entries at once.
	- Click on the right arrow button (→) to add the selected data channels.

7. Modify active data channels.
	- The panel on the right displays all active data channels.
	- Click on an entry in the right panel to select it. Modifier keys cannot be used.
		- Click on the left arrow button (←) to remove the entry from the list.
		- Click on the up or down arrow buttons to change the position of the entry.
	- The CSV file will be written in the same order.
		- E.g., the topmost channel will form the first column.

> [!TIP]
> Due to fluctuations in recording frequency, the simulator elapsed time (`time_elapsed`) should always be included.

8. Control the recording.
	- Click on the "TRAIN CREW" button to start the recording.
		- Writing is paused when the game is loading, paused, or in a menu other than the driving screen. This allows multiple runs to be included in a single file.
	- Click on the "STOP" button to stop recording.

9. Review your data.
	- The CSV file can be opened in common office software.

## Data Channels

The information here is focused on data that is more relevant to train and driver performance, or has unique behaviors that can cause problems if not accounted for. Refer to [Rudolf specifications](https://github.com/haruyukitanuki/Rudolf/tree/main/spec) for more information.

> [!IMPORTANT]
> Data channels can produce null values. This happens when they are not supported, no data is present at that time, or when the null value carries a special meaning.

| Name | Description |
| :--- | :--- |
| time_sim | [Text] Simulator time as a string.
| time_elapsed | [Number] [s] Time in seconds, starting from an arbitrary number.
| time_tick | [Number] Rudolf internal tick counter.
| diagram_trainNumber | [Text]
| diagram_boundFor | [Text]
| diagram_serviceType | [Text]
| diagram_direction | [Text]
| diagram_runNumber | [Text]
| stations_currentIndex | [Number] Null when not stopped at a station.
| stations_nextIndex | [Number]
| stations_next_name | [Text]
| stations_next_fromStartDistance | [Number] [m] See `physics_fromStartDistance`.
| stations_next_absoluteDistance | [Number] [m] See `physics_absoluteDistance`.
| stations_next_doorSide | [Number] See `doors_perCar_SideOpened`.
| stations_next_stopType | [Text]
| stations_next_arrival | [Text]
| stations_next_departure | [Text]
| stations_next_stopPositionName | [Text]
| stations_next_isTimeTaken | [Boolean]
| physics_speed | [Number] [km/h]
| physics_fromStartDistance | [Number] [m] Forward distance since the start point.
| physics_absoluteDistance | [Number] [m] Absolute kilometer-post position on the route.
| physics_gradient | [Number] [‰ (permille)]
| physics_mrPressure | [Number] [kPa] Main reservoir (MR).
| controllers_powerNotch | [Number] In TRAIN CREW, the HB positions on two-handle trains count as negative power notches.
| controllers_brakeNotch | [Number] In TRAIN CREW, the HB position on one-handle trains counts as brake notch 1.
| controllers_reverser | [Number] {-1 (reverse), 0, 1 (forward)}
| controllers_ato_active | [Boolean]
| controllers_ato_notch | [Number]
| controllers_tasc_active | [Boolean]
| controllers_tasc_notch | [Number]
| controllers_tasc_inching | [Boolean]
| controllers_deadman | [Text]
| doors_allClosed | [Boolean]
| doors_perCar_carNo | [Number] [Multi-column]
| doors_perCar_sideOpened | [Number] [Multi-column] {-1 (left side open), 0 (closed), 1 (right side open), 2 (both sides open), 3 (unknown side open), null} In TRAIN CREW, only states 0 and 3 are supported.
| lamps_doorClose | [Number]
| lamps_atsReady | [Number]
| lamps_atsBrakeApply | [Number]
| lamps_atsOpen | [Number]
| lamps_regenerative | [Number]
| lamps_ebTimer | [Number]
| lamps_emergencyBrake | [Number]
| lamps_overload | [Number]
| lamps_pilot | [Number]
| lamps_ato | [Number]
| ats_class | [Text]
| ats_speed | [Number] {[km/h], -1 (unlimited), null (blank display)}
| ats_state | [Text]
| signals_next_name | [Text]
| signals_next_type | [Text]
| signals_next_phase | [Number] {0 (off), 1 (R), 2 (YY), 3 (Y), 4 (YG), 5 (YG flashing), 6 (G), 7 (GG), other sim-specific values} Speed to be determined from Simulator Profile.
| signals_next_distance | [Number] [m]
| speedLimit_current | [Number] [km/h]
| speedLimit_currentType | [Text]
| speedLimit_next | [Number] [km/h]
| speedLimit_next_distance | [Number] [m]
| speedLimit_next_type | [Text]
| cars_carNo | [Number] [Multi-column]
| cars_bcPressure | [Number] [Multi-column] [kPa] Brake cylinder (BC). In BVE, only one value is produced.
| cars_amperage | [Number] [Multi-column] [A] Motor current draw. In BVE, only three values are produced. The first value is the current shown in the driver's cab. The other two values are a small number.
| cars_occupancyRate | [Number] [Multi-column] [%] Car fill as a percentage, i.e., 50 (not 0.5) if the car is 50% full. Can exceed 100. Supported in TRAIN CREW. Not available in BVE.
| switches_hornAir | [Boolean]
| switches_hornElectric | [Boolean]
| switches_buzzerDriver | [Boolean]
| switches_buzzerConductor | [Boolean]
| switches_headlights | [Boolean]
| switches_highBeam | [Boolean]
| switches_wiper | [Text]