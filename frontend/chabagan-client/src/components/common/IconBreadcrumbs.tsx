import * as React from 'react';
import Typography from '@mui/material/Typography';
import Breadcrumbs from '@mui/material/Breadcrumbs';
import { IIconBreadcrumbs } from '../../interfaces/IBreadcrumbs';
import { Link } from 'react-router-dom';

function handleClick(event: React.MouseEvent<HTMLDivElement, MouseEvent>) {
    event.preventDefault();
    console.info('You clicked a breadcrumb.');
}

export const IconBreadcrumbs: React.FC<{ props: IIconBreadcrumbs[] }> = ({ props }) => {

    return (
        <div role="presentation" onClick={handleClick}>
            <Breadcrumbs aria-label="breadcrumb">
                {props.map((item, index) => {
                    if (item.isLast) {
                        return (
                            <Typography
                                key={index}
                                sx={{ display: 'flex', alignItems: 'center' }}
                                color="text.primary"
                            >
                                {item.icon}
                                {item.text}
                            </Typography>
                        )
                    } else {
                        return (
                            <Link
                                color="inherit"
                                key={index}
                                to={`${item.path}`}
                            >
                                {item.icon}
                                {item.text}
                            </Link>
                        )
                    }

                })}
            </Breadcrumbs>
        </div>
    );
}
