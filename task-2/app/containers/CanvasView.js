import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import Canvas from '../components/Canvas';
import * as CounterActions from '../actions/counter';

const figureMock = [
	{
		type: 'ellipse',
		cx: 200,
		cy: 80,
		rx: 100,
		ry: 50,
		fill: 'yellow'
	}
];

const mapStateToProps = connect(
	state => ({
		counter: state.counter,
		figures: figureMock
	}),
	dispatch => ({
		...bindActionCreators(CounterActions, dispatch),
		drawEllipse: points => {
			const center = {
				x: (points[1].x + points[0].x) / 2,
				y: (points[1].y + points[0].y) / 2
			};
			figureMock.push({
				type: 'ellipse',
				fill: '#ff0001',
				cx: center.x,
				cy: center.y,
				rx: Math.abs(points[1].x - center.x),
				ry: Math.abs(points[1].y - center.y)
			});
		}
	})
);

export default mapStateToProps(Canvas);
