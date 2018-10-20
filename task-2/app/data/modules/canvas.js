// Types
const CANVAS_PREFIX = 'CANVAS:';
const ADD_ELLIPSE = `${CANVAS_PREFIX}ADD_ELLIPSE`;

// Actions
const addEllipse = (points) => {
	const center = {
		x: (points[1].x + points[0].x) / 2,
		y: (points[1].y + points[0].y) / 2
	};
	return {
		type: ADD_ELLIPSE,
		payload: {
			type: 'ellipse',
			fill: '#ff0001',
			cx: center.x,
			cy: center.y,
			rx: Math.abs(points[1].x - center.x),
			ry: Math.abs(points[1].y - center.y)
		}
	}
};

// Reducer
const defaultState = {
	figures: [
		{
			type: 'ellipse',
			cx: 200,
			cy: 80,
			rx: 100,
			ry: 50,
			fill: 'yellow'
		}
	]
};
const reducer = (state = defaultState, action) => {
	switch (action.type) {
		case ADD_ELLIPSE:
			return {...state, figures: [...state.figures, action.payload]};
		default:
			return state;
	}
};

export default reducer;
export {
	addEllipse,
}
