import * as React from 'react';
import Typography from '@mui/material/Typography';
import Breadcrumbs from '@mui/material/Breadcrumbs';
import Link from '@mui/material/Link';
import { IIconBreadcrumbs } from '../../interfaces/IBreadcrumbs';

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
                                underline="hover"
                                sx={{ display: 'flex', alignItems: 'center' }}
                                color="inherit"
                                href={item.path}
                                key={index}
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
