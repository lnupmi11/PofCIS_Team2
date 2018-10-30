import fs from 'fs';

// Types
const CANVAS_PREFIX = 'CANVAS:';
const ADD_ELLIPSE = `${CANVAS_PREFIX}ADD_ELLIPSE`;
const LOAD_FIGURES = `${CANVAS_PREFIX}LOAD_FIGURES`;
const SAVE_FIGURES = `${CANVAS_PREFIX}SAVE_FIGURES`;
const ERROR = `${CANVAS_PREFIX}ERROR`;

// Actions
const addEllipse = (points, color) => {
	const center = {
		x: (points[1].x + points[0].x) / 2,
		y: (points[1].y + points[0].y) / 2
	};
	return {
		type: ADD_ELLIPSE,
		payload: {
			type: 'ellipse',
			fill: color,
			cx: center.x,
			cy: center.y,
			rx: Math.abs(points[1].x - center.x),
			ry: Math.abs(points[1].y - center.y)
		}
	};
};

const loadFigures = dispatch => file => {
	console.log(file);
	fs.exists(file, exists => {
		if (exists) {
			fs.readFile(file, 'utf8', (err, text) => {
				if (err) {
					dispatch({
						type: ERROR,
						payload: err
					});
				} else {
					const data = JSON.parse(text);
					if (data)
						dispatch({
							type: LOAD_FIGURES,
							payload: {
								filename: file,
								figures: data
							}
						});
				}
			});
		}
	});
};

const saveFigures = dispatch => (file, data) => {
	fs.writeFile(file, JSON.stringify(data), err => {
		dispatch({
			type: SAVE_FIGURES,
			payload: !err
		});
	});
};

// Reducer
const defaultState = {
	filename: 'saves/new_save.json',
	figures: []
};
const reducer = (state = defaultState, action) => {
	switch (action.type) {
		case ADD_ELLIPSE:
			return { ...state, figures: [...state.figures, action.payload] };
		case LOAD_FIGURES:
			return {
				...state,
				figures: action.payload.figures,
				filename: action.payload.filename
			};
		default:
			return state;
	}
};

export default reducer;
export { addEllipse, loadFigures, saveFigures };
