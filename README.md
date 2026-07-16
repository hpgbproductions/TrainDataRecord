# TrainDataRecord

Data logger for TRAIN CREW. You can easily export train telemetry data in CSV files, enabling analysis of train and driving performance.

## Credits

Uses libraries for [Rudolf](https://github.com/haruyukitanuki/Rudolf) and the [TrainCrew adapter](https://github.com/haruyukitanuki/Rudolf.Adapters.TrainCrew) by [Haruyuki Tanukiji](https://github.com/haruyukitanuki).

## Guide

1. Choose the location and name of the CSV file.
	- Type the location, or click on the "..." button to open the file picker.
	- If the file already exists, it will be **overwritten**.
		- No warning will be given when using the text box to choose the location.
		- The file is created when the recording is started.
	- Using a relative file path (without drive letter) will generate the file in the same folder as the EXE.

2. Choose the frequency of data reading.
	- Due to CPU timing inaccuracies, the duration between data points may fluctuate slightly.
	- Timing will be irregular at the point of pausing the game, using fast forward, etc.

3. Choose the number of train cars.
	- This only has an effect when reading per-car data.
	- If the number chosen is larger than the actual number of cars, empty columns will be present, but no data will be lost.
	- Conversely, if the number chosen is too small, data from part of the train will be lost.

4. Check your system locale.
	- "European Mode" changes the CSV format for decimal-comma locales.

5. Add data channels to read.
	- Click on an entry in the left panel to select it. You can use the Ctrl and Shift modifier keys.
	- Click on the right arrow button to add the selected data channels.

6. Modify active data channels.
	- Click on an entry in the right panel to select it. Modifier keys cannot be used.
	- Click on the left arrow button to remove it from the list.
	- Click on the up or down arrow buttons to change its position. This changes the column order in the CSV file.

7. Control the recording.
	- Click on the "TRAIN CREW" button to enter the recording mode.
		- Data will be written according to the settings chosen.
		- Writing is paused when the game is loading, paused, or in a menu other than the driving screen. Therefore, multiple runs can be included in a single file.
	- Click on the "STOP" button to stop recording.
		- The data will now be accessible.