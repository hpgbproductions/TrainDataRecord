# TrainDataRecord

Data logger for TRAIN CREW. Exports train telemetry data in CSV files for later analysis of train and driving performance.

## Credits

Uses libraries for [Rudolf](https://github.com/haruyukitanuki/Rudolf) and the [TrainCrew adapter](https://github.com/haruyukitanuki/Rudolf.Adapters.TrainCrew) by [Haruyuki Tanukiji](https://github.com/haruyukitanuki).

## Step-by-Step Guide

1. Choose the location and name of the CSV file.
	- Type the location in the text box, or click on the "..." button to open the file picker.
	- Use a relative file path (without drive letter) to generate the file in the same folder as the EXE.

> [!CAUTION]
> If the file already exists, **it will be overwritten.** No warning is given if the path is entered using the text box. The file is written when the recording is started.

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

5. Decide if the simulator profile should be generated.
	- The file will be generated at `[file path from step 1].sp.json`.
	- This file will be overwritten each time the simulator profile is changed.

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